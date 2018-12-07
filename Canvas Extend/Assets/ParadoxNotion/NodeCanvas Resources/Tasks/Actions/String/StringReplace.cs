using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions
{
    [Category("String")]
    [Description("Replace a substring with a new String.")]
    public class StringReplace : ActionTask
    {
        public BBParameter<string> valueA;
        public BBParameter<string> replace;
        public BBParameter<string> with;
        [BlackboardOnly]
        public BBParameter<string> storeResult;
        protected override string info
        {
            get { return string.Format("{0}.Replace({1},{2})", valueA, replace, with); }
        }
        protected override void OnExecute()
        {
            storeResult.value = valueA.value.Replace(replace.value, with.value);
            EndAction();
        }
    }
}