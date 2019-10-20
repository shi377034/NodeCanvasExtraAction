using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions{
	[Category("✫ Structs")]
	[Description("Set a Struct integer variable")]
	public class SetStructVariable<T> : StructActionBase
    {
        [SerializeField]
        public BBParameter<T> valueA;
		public BBParameter<T> valueB;

        protected override string info
        {
            get { return string.Format("{0}.{1} = {2}", Struct, valueA, valueB); }
        }
        protected override string OnInit()
        {
            base.OnInit();
            valueA.bb = Struct.value;
            return null;
        }
        protected override void OnExecute(){
            valueA.value = valueB.value;
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
                NodeCanvas.Editor.BBParameterEditor.ParameterField("valueB", valueB, false);
            }
        }
#endif
    }
}