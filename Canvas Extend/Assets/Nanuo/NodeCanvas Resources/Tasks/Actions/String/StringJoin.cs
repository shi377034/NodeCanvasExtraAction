using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions
{
    [Category("String")]
    [Description("Join an array of strings into a single string.")]
    public class StringJoin : ActionTask
    {
        public BBParameter<string[]> valueA;
        public BBParameter<string> separator;
        [BlackboardOnly]
        public BBParameter<string> storeResult;
        protected override string info
        {
            get { return string.Format("string.Join({0},{1})", separator, valueA); }
        }
        protected override void OnExecute()
        {
            storeResult.value = string.Join(separator.value, valueA.value);
            EndAction();
        }
    }
}