using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;
namespace NodeCanvas.Tasks.Actions
{
    [Category("Convert")]
    public class ConvertStringToInt : ActionTask
    {
        public BBParameter<string> stringVariable;
        [BlackboardOnly]
        public BBParameter<int> store;
        protected override string info
        {
            get
            {
                return string.Format("{0} To {1}", stringVariable.ToString(), store.ToString());
            }
        }
        protected override void OnExecute()
        {
            store.value = int.Parse(stringVariable.value);
            EndAction();
        }
    }
}