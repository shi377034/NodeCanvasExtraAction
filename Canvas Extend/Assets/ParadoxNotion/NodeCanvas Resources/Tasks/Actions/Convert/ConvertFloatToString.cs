using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;
namespace NodeCanvas.Tasks.Actions
{
    [Category("Convert")]
    public class ConvertFloatToString : ActionTask
    {

        public BBParameter<float> floatVariable;
        public BBParameter<string> format;
        [BlackboardOnly]
        public BBParameter<string> store;

        protected override string info
        {
            get
            {
                return string.Format("{0} To {1}", floatVariable.ToString(), store.ToString());
            }
        }
        protected override void OnExecute()
        {
            if (string.IsNullOrEmpty(format.value))
            {
                store.value = floatVariable.value.ToString();
            }
            else
            {
                store.value = floatVariable.value.ToString(format.value);
            }
            EndAction();
        }
    }
}