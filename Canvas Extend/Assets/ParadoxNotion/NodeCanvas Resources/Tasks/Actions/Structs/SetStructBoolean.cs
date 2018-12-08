using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{

    [Name("Set Integer")]
    [Category("✫ Structs")]
    [Description("Set a Struct integer variable")]
    public class SetStructBoolean : StructActionBase
    {
        public enum BoolSetModes
        {
            False = 0,
            True = 1,
            Toggle = 2
        }
        [SerializeField]
        public BBParameter<bool> valueA;
        public BoolSetModes setTo = BoolSetModes.True;
        protected override string info
        {
            get
            {
                string valueInfo = "";
                switch (setTo)
                {
                    case BoolSetModes.True:
                        valueInfo = "True";
                        break;
                    case BoolSetModes.False:
                        valueInfo = "False";
                        break;
                    case BoolSetModes.Toggle:
                        valueInfo = string.Format("!{0}.{1}", Struct, valueA);
                        break;
                }
                return string.Format("{0}.{1} = {2}", Struct, valueA, valueInfo);
            }
        }
        protected override string OnInit()
        {
            base.OnInit();
            valueA.bb = Struct.value;
            return null;
        }
        protected override void OnExecute()
        {
            if (setTo == BoolSetModes.Toggle)
            {
                valueA.value = !valueA.value;
            }
            else
            {
                var checkBool = ((int)setTo == 1);
                valueA.value = checkBool;
            }
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
                setTo = (BoolSetModes)UnityEditor.EditorGUILayout.EnumPopup("setTo", setTo);
            }
        }
#endif
    }
}