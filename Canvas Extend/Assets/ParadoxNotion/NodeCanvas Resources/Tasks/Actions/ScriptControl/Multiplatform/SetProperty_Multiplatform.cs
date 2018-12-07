using System.Reflection;
using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion;
using ParadoxNotion.Design;
using ParadoxNotion.Serialization;
using UnityEngine;
using System.Linq;


namespace NodeCanvas.Tasks.Actions {

	[Category("✫ Script Control/Multiplatform")]
	[Description("Set a property on a script")]
	public class SetPropertyMultiplatform<T> : ActionTask {
        [SerializeField]
        public BBParameter<T> target;
        [SerializeField]
		protected SerializedMethodInfo method;
		[SerializeField]
		protected BBObjectParameter parameter;

		private MethodInfo targetMethod{
			get {return method != null? method.Get() : null;}
		}

		protected override string info{
			get
			{
				if (method == null){
					return "No Property Selected";
				}
				if (targetMethod == null){
					return string.Format("<color=#ff6457>* {0} *</color>", method.GetMethodString() );
				}
				var mInfo = targetMethod.IsStatic? targetMethod.RTReflectedType().FriendlyName() : target.ToString();
				return string.Format("{0}.{1} = {2}", mInfo, targetMethod.Name, parameter.ToString() );
			}
		}

		public override void OnValidate(ITaskSystem ownerSystem){
			if (method != null && method.HasChanged()){	
				SetMethod(method.Get());
			}
			if (method != null && method.Get() == null){
				Error( string.Format("Missing Property '{0}'", method.GetMethodString()) );
			}
		}

		protected override string OnInit(){
			if (method == null){
				return "No property selected";
			}
			if (targetMethod == null){
				return string.Format("Missing property '{0}'", method.GetMethodString());
			}
			return null;
		}

		protected override void OnExecute(){
            object instance = targetMethod.IsStatic ? default(T) : target.value;
            targetMethod.Invoke(instance, new object[]{parameter.value});
            target.value = (T)instance;
            EndAction();
		}

		void SetMethod(MethodInfo method){
			if (method != null){
				this.method = new SerializedMethodInfo(method);
				this.parameter.SetType(method.GetParameters()[0].ParameterType);				
			}
		}


		///----------------------------------------------------------------------------------------------
		///---------------------------------------UNITY EDITOR-------------------------------------------
		#if UNITY_EDITOR
		
		protected override void OnTaskInspectorGUI(){
            if (!Application.isPlaying && GUILayout.Button("Select Property")){
				var menu = new UnityEditor.GenericMenu();
				foreach (var t in TypePrefs.GetPreferedTypesList(typeof(T))){
					menu = EditorUtils.GetStaticMethodSelectionMenu(t, typeof(void), typeof(object), SetMethod, 1, true, false, menu);
					if (typeof(T).IsAssignableFrom(t)){
						menu = EditorUtils.GetInstanceMethodSelectionMenu(t, typeof(void), typeof(object), SetMethod, 1, true, false, menu);
					}
				}
                if (menu.GetItemCount() <= 0)
                {
                    menu.AddItem(new GUIContent("No Propertys"), false, null);
                }
                menu.ShowAsBrowser("Select Property", this.GetType());
				Event.current.Use();				
			}

			if (targetMethod != null){
                if (!targetMethod.IsStatic) NodeCanvas.Editor.BBParameterEditor.ParameterField("Instance", target, true);
                GUILayout.BeginVertical("box");
				UnityEditor.EditorGUILayout.LabelField("Type", targetMethod.RTReflectedType().FriendlyName());
				UnityEditor.EditorGUILayout.LabelField("Property", targetMethod.Name);
				UnityEditor.EditorGUILayout.LabelField("Set Type", parameter.varType.FriendlyName() );
				GUILayout.EndVertical();
				NodeCanvas.Editor.BBParameterEditor.ParameterField("Set Value", parameter);
			}
		}

		#endif
	}
}