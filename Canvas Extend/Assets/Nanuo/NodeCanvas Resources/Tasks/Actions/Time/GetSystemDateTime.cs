using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("Time")]
    [Description("Gets system date and time info and stores it in a string variable. An optional format string gives you a lot of control over the formatting (see online docs for format syntax).")]
    public class GetSystemDateTime : ActionTask
    {
        [BlackboardOnly]
        [Tooltip("Store System DateTime as a string.")]
        public BBParameter<string> storeString;
        [Tooltip("Optional format string. E.g., MM/dd/yyyy HH:mm")]
        public BBParameter<string> format = "MM/dd/yyyy HH:mm";
        protected override string info
        {
            get { return storeString + " = DateTime.Now"; }
        }
        protected override void OnExecute()
        {
            storeString.value = System.DateTime.Now.ToString(format.value);
            EndAction();
        }
    }
}