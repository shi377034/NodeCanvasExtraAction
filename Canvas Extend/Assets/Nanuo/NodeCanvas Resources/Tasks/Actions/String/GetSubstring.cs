using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("String")]
    [Description("Gets a sub-string from a String Variable.")]
    public class GetSubstring : ActionTask
    {
        [RequiredField]
        public BBParameter<string> stringVariable;
        public BBParameter<int> startIndex;
        public BBParameter<int> length;
        [BlackboardOnly]
        public BBParameter<string> storeResult;
        private string result;
        protected override void OnExecute()
        {
            DoGetSubstring();
            EndAction();
        }
        void DoGetSubstring()
        {
            storeResult.value = stringVariable.value.Substring(startIndex.value, length.value);
        }
    }
}