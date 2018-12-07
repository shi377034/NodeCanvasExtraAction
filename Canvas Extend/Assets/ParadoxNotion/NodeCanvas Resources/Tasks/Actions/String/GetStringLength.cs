using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("String")]
    public class GetStringLength : ActionTask
    {
        [RequiredField]
        public BBParameter<string> stringVariable;
        [BlackboardOnly]
        public BBParameter<int> storeResult;
        private string result;
        protected override void OnExecute()
        {
            storeResult.value = stringVariable.value.Length;
            EndAction();
        }
    }
}