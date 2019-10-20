using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{

    [Name("Set Vector3")]
    [Category("✫ Structs")]
    [Description("Set a Struct integer variable")]
    public class SetStructVector3 : StructActionBase
    {
        [SerializeField]
        public BBParameter<Vector3> valueA;
        public OperationMethod Operation = OperationMethod.Set;
        public BBParameter<Vector3> valueB;

        protected override string info
        {
            get { return string.Format("{0}.{1} {2} {3}", Struct, valueA, OperationTools.GetOperationString(Operation), valueB); }
        }
        protected override string OnInit()
        {
            base.OnInit();
            valueA.bb = Struct.value;
            return null;
        }
        protected override void OnExecute()
        {
            valueA.value = OperationTools.Operate(valueA.value, valueB.value, Operation);
            EndAction();
        }
#if UNITY_EDITOR
        protected override void OnTaskInspectorGUI()
        {
            NodeCanvas.Editor.BBParameterEditor.ParameterField("Struct", Struct, true);
            if (Struct.value != null)
            {
                valueA.bb = Struct.value;
                NodeCanvas.Editor.BBParameterEditor.ParameterField("valueA", valueA, true);
                Operation = (OperationMethod)UnityEditor.EditorGUILayout.EnumPopup("Operation", Operation);
                NodeCanvas.Editor.BBParameterEditor.ParameterField("valueB", valueB, false);
            }
        }
#endif
    }
}