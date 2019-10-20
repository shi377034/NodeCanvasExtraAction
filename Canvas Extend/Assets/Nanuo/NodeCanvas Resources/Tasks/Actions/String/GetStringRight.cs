using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("String")]
    [Description("Gets the Right n characters from a String.")]
    public class GetStringRight : ActionTask
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
            DoGetStringRight();
            EndAction();
        }
        void DoGetStringRight()
        {
            var text = stringVariable.value;
            var count = Mathf.Clamp(charCount.value, 0, text.Length);
            storeResult.value = text.Substring(text.Length - count, count);
        }
    }
}