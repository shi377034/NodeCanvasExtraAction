using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;
namespace NodeCanvas.Tasks.Actions
{
    [Category("Convert")]
    public class ConvertIntToFloat : ActionTask
    {
        public BBParameter<int> intVariable;
        [BlackboardOnly]
        public BBParameter<float> store;
        protected override string info
        {
            get
            {
                return string.Format("{0} To {1}", intVariable.ToString(), store.ToString());
            }
        }
        protected override void OnExecute()
        {
            store.value = intVariable.value;
            EndAction();
        }
    }
}