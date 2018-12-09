using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("String")]
    [Description("Gets the Left n characters from a String Variable.")]
    public class GetStringLeft : ActionTask
    {
        [RequiredField]
        public BBParameter<string> stringVariable;
        [Tooltip("Number of characters to get.")]
        public BBParameter<int> charCount;
        [BlackboardOnly]
        public BBParameter<string> storeResult;
        private string result;
        protected override void OnExecute()
        {
            DoGetStringLeft();
            EndAction();
        }
        void DoGetStringLeft()
        {
            storeResult.value = stringVariable.value.Substring(0, Mathf.Clamp(charCount.value, 0, stringVariable.value.Length));
        }
    }
}