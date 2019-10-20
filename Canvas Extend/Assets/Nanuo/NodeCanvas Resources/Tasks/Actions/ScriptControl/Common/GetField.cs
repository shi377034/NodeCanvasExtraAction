using System.Reflection;
using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;
using System.Linq;

namespace NodeCanvas.Tasks.Actions{

	[Category("✫ Script Control/Common")]
	[Description("Get a variable of a script and save it to the blackboard")]
	public class GetField<T> : ActionTask {
        [SerializeField]
        public BBParameter<T> target;
		[SerializeField]
		protected System.Type targetType;
		[SerializeField]
		protected string fieldName;
		[SerializeField] [BlackboardOnly]
		protected BBObjectParameter saveAs;
        [SerializeField]
        protected bool IsStatic;

        private FieldInfo field;

		protected override string info{
			get
			{
				if (string.IsNullOrEmpty(fieldName))
					return "No Field Selected";
				return string.Format("{0} = {1}.{2}", saveAs.ToString(), target, fieldName);
			}
		}

		protected override string OnInit(){
			field = typeof(T).RTGetField(fieldName);
			if (field == null)
				return "Missing Field: " + fieldName;
			return null;
		}

		protected override void OnExecute(){
            object instance = field.IsStatic ? default(T) : target.value;
            saveAs.value = field.GetValue(instance);
			EndAction();
		}

		////////////////////////////////////////
		///////////GUI AND EDITOR STUFF/////////
		////////////////////////////////////////
		#if UNITY_EDITOR

		protected override void OnTaskInspectorGUI(){
            
            if (!Application.isPlaying && GUILayout.Button("Select Field")){
				
				System.Action<FieldInfo> FieldSelected = (field)=> {
					targetType = field.DeclaringType;
					fieldName = field.Name;
					saveAs.SetType(field.FieldType);
                    IsStatic = field.IsStatic;

                };

				var menu = new UnityEditor.GenericMenu();
				foreach (var t in TypePrefs.GetPreferedTypesList(typeof(T))){
					menu = EditorUtils.GetInstanceFieldSelectionMenu(t, typeof(object), FieldSelected, menu);
				}
                if(menu.GetItemCount()<=0)
                {
                    menu.AddItem(new GUIContent("No Fields"), false, null);
                }
				menu.ShowAsBrowser("Select Field", this.GetType());
				Event.current.Use();
			}


			if (!string.IsNullOrEmpty(fieldName)){
                if(!IsStatic) NodeCanvas.Editor.BBParameterEditor.ParameterField("Instance", target, true);
                GUILayout.BeginVertical("box");
				UnityEditor.EditorGUILayout.LabelField("Type", typeof(T).Name);
				UnityEditor.EditorGUILayout.LabelField("Field", fieldName);
				UnityEditor.EditorGUILayout.LabelField("Field Type", saveAs.varType.FriendlyName() );
				GUILayout.EndVertical();
				NodeCanvas.Editor.BBParameterEditor.ParameterField("Save As", saveAs, true);
			}
		}

		#endif
	}
}
