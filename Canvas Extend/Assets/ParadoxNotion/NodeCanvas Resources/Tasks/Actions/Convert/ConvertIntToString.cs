using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;
namespace NodeCanvas.Tasks.Actions
{
    [Category("Convert")]
    public class ConvertIntToString : ActionTask
    {
        public BBParameter<int> intVariable;
        public BBParameter<string> format;
        [BlackboardOnly]
        public BBParameter<string> store;
        protected override string info
        {
            get
            {
                return string.Format("{0} To {1}", intVariable.ToString(), store.ToString());
            }
        }
        protected override void OnExecute()
        {
            if (string.IsNullOrEmpty(format.value))
            {
                store.value = intVariable.value.ToString();
            }
            else
            {
                store.value = intVariable.value.ToString(format.value);
            }
            EndAction();
        }
    }
}