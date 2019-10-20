using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("String")]
    [Description("Adds a String to the end of a String.")]
    public class StringAppend : ActionTask
    {
        [BlackboardOnly]
        public BBParameter<string> valueA;
        public BBParameter<string> appendString;
        protected override string info
        {
            get { return valueA + " += " + appendString; }
        }
        protected override void OnExecute()
        {
            valueA.value += appendString.value;
            EndAction();
        }
    }
}