using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("String")]
    public class BuildString : ActionTask
    {
        public BBParameter<string[]> stringParts;
        public BBParameter<string> separator;
        public BBParameter<bool> addToEnd;
        [BlackboardOnly]
        public BBParameter<string> storeResult;
        private string result;
        protected override void OnExecute()
        {
            DoBuildString();
            EndAction();
        }
        void DoBuildString()
        {
            result = "";

            for (var i = 0; i < stringParts.value.Length - 1; i++)
            {
                result += stringParts.value[i];
                result += separator.value;
            }
            result += stringParts.value[stringParts.value.Length - 1];

            if (addToEnd.value)
            {
                result += separator.value;
            }

            storeResult.value = result;
        }
    }
}