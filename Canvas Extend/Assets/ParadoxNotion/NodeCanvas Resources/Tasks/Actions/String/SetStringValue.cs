using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("String")]
    [Description("Sets the value of a String Variable.")]
    public class SetStringValue : ActionTask
    {
        [BlackboardOnly]
        public BBParameter<string> valueA;
        [TextAreaField(20)]
        public BBParameter<string> valueB;
        protected override string info
        {
            get { return valueA + " = " + valueB; }
        }
        protected override void OnExecute()
        {
            valueA.value = valueB.value;
            EndAction();
        }
    }
}