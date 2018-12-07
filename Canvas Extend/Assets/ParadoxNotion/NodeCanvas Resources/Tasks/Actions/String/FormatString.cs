using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("String")]
    public class FormatString : ActionTask
    {
        [RequiredField]
        [Tooltip("E.g. Hello {0} and {1}\nWith 2 variables that replace {0} and {1}\nSee C# string.Format docs.")]
        public BBParameter<string> format;
        [Tooltip("Variables to use for each formatting item.")]
        public BBParameter[] variables;
        [BlackboardOnly]
        public BBParameter<string> storeResult;
        private object[] objectArray;
        protected override void OnExecute()
        {
            objectArray = new object[variables.Length];
            DoFormatString();
            EndAction();
        }
        void DoFormatString()
        {
            for (var i = 0; i < variables.Length; i++)
            {
                objectArray[i] = variables[i].value;
            }
            storeResult.value = string.Format(format.value, objectArray);
        }
    }
}