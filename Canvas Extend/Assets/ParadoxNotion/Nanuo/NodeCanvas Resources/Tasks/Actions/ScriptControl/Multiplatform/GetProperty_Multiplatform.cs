using System.Reflection;
using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion;
using ParadoxNotion.Design;
using ParadoxNotion.Serialization;
using UnityEngine;
using System.Linq;


namespace NodeCanvas.Tasks.Actions{
	[Category("✫ Script Control/Multiplatform")]
	[Description("Get a property of a script and save it to the blackboard")]
	public class GetPropertyMultiplatform<T> : ActionTask {
        [SerializeField]
        public BBParameter<T> target;
        [SerializeField]
		protected SerializedMethodInfo method;
		[SerializeField] [BlackboardOnly]
		protected BBObjectParameter returnValue;

		private MethodInfo targetMethod{
			get {return method != null? method.Get() : null; }
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
				var mInfo = targetMethod.IsStatic? targetMethod.RTReflectedOrDeclaredType().FriendlyName() : target.ToString();
				return string.Format("{0} = {1}.{2}", returnValue.ToString(), mInfo, targetMethod.Name);
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

		//store the method info on init for performance
		protected override string OnInit(){
			if (method == null){
				return "No Property selected";
			}
			if (targetMethod == null){
				return string.Format("Missing Property '{0}'", method.GetMethodString());
			}
			return null;
		}

		//do it by invoking method
		protected override void OnExecute(){
            object instance = targetMethod.IsStatic ? default(T) : target.value;
            returnValue.value = targetMethod.Invoke(instance, null);
            target.value = (T)instance;
            EndAction();
		}

		void SetMethod(MethodInfo method){
			if (method != null){
				this.method = new SerializedMethodInfo(method);
				this.returnValue.SetType(method.ReturnType);			
			}
		}


		///----------------------------------------------------------------------------------------------
		///---------------------------------------UNITY EDITOR-------------------------------------------
		#if UNITY_EDITOR
		
		protected override void OnTaskInspectorGUI(){
            if (!Application.isPlaying && GUILayout.Button("Select Property")){
				var menu = new UnityEditor.GenericMenu();
				foreach (var t in TypePrefs.GetPreferedTypesList(typeof(T))){
					menu = EditorUtils.GetStaticMethodSelectionMenu(t, typeof(object), typeof(object), SetMethod, 0, true, true, menu);
					if (typeof(T).IsAssignableFrom(t)){
						menu = EditorUtils.GetInstanceMethodSelectionMenu(t, typeof(object), typeof(object), SetMethod, 0, true, true, menu);
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
				UnityEditor.EditorGUILayout.LabelField("Type", targetMethod.RTReflectedOrDeclaredType().FriendlyName());
				UnityEditor.EditorGUILayout.LabelField("Property", targetMethod.Name);
				UnityEditor.EditorGUILayout.LabelField("Property Type", targetMethod.ReturnType.FriendlyName() );
				GUILayout.EndVertical();
				NodeCanvas.Editor.BBParameterEditor.ParameterField("Save As", returnValue, true);
			}
		}

		#endif
	}
}
