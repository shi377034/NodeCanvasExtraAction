using System.Reflection;
using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;
using System.Linq;


namespace NodeCanvas.Tasks.Actions{

	[Category("✫ Script Control/Standalone Only")]
	[Description("Get a property of a script and save it to the blackboard")]
	public class GetProperty<T> : ActionTask, ISubParametersContainer {
        [SerializeField]
        public BBParameter<T> target;
        [SerializeField] /* [IncludeParseVariables] */
		protected ReflectedFunctionWrapper functionWrapper;

		BBParameter[] ISubParametersContainer.GetSubParameters(){
			return functionWrapper != null? functionWrapper.GetVariables() : null;
		}

		private MethodInfo targetMethod{
			get {return functionWrapper != null? functionWrapper.GetMethod() : null; }
		}

		protected override string info{
			get
			{
				if (functionWrapper == null){
					return "No Property Selected";
				}
				if (targetMethod == null){
					return string.Format("<color=#ff6457>* {0} *</color>", functionWrapper.GetMethodString() );
				}
				var mInfo = targetMethod.IsStatic? targetMethod.RTReflectedOrDeclaredType().FriendlyName() : target.ToString();
				return string.Format("{0} = {1}.{2}", functionWrapper.GetVariables()[0], mInfo, targetMethod.Name);
			}
		}

		public override void OnValidate(ITaskSystem ownerSystem){
			if (functionWrapper != null && functionWrapper.HasChanged()){	
				SetMethod(functionWrapper.GetMethod());
			}
			if (functionWrapper != null && targetMethod == null){
				Error(string.Format("Missing Property '{0}'", functionWrapper.GetMethodString()));
			}
		}

		//store the method info on init for performance
		protected override string OnInit(){

			if (functionWrapper == null){
				return "No Property selected";
			}
			if (targetMethod == null){
				return string.Format("Missing Property '{0}'", functionWrapper.GetMethodString());
			}

			try
			{
                object instance = targetMethod.IsStatic ? default(T) : target.value;
                functionWrapper.Init(instance);
				return null;
			}
			catch {return "GetProperty Error";}
		}

		//do it by invoking method
		protected override void OnExecute(){

			if (functionWrapper == null){
				EndAction(false);
				return;
			}

			functionWrapper.Call();
			EndAction();
		}

		void SetMethod(MethodInfo method){
			if (method != null){
				functionWrapper = ReflectedFunctionWrapper.Create(method, blackboard);
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
				NodeCanvas.Editor.BBParameterEditor.ParameterField("Save As", functionWrapper.GetVariables()[0], true);
			}
		}

		#endif
	}
}
