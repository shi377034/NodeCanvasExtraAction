using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions{
	[Category("✫ Structs")]
	[Description("Set a Struct integer variable")]
	public class GetStructVariable<T> : StructActionBase
    {
        [SerializeField]
        public BBParameter<T> valueA;
		public BBParameter<T> saveAs;

		protected override string info{
			get	{ return string.Format("{0} = {1}.{2}", saveAs, Struct, valueA); }
		}
        protected override string OnInit()
        {
            base.OnInit();
            valueA.bb = Struct.value;
            return null;
        }
        protected override void OnExecute(){
            saveAs.value = valueA.value;

            EndAction();
		}
#if UNITY_EDITOR
        protected override void OnTaskInspectorGUI()
        {
            NodeCanvas.Editor.BBParameterEditor.ParameterField("Struct", Struct, true);
            if(Struct.value != null)
            {
                valueA.bb = Struct.value;
                NodeCanvas.Editor.BBParameterEditor.ParameterField("valueA", valueA, true);
                NodeCanvas.Editor.BBParameterEditor.ParameterField("valueB", saveAs, true);
            }
        }
#endif
    }
}