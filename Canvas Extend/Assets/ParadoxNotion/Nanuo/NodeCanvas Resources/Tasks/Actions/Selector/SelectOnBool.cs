using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;
namespace NodeCanvas.Tasks.Actions{
    [Category("Selector")]
    public class SelectOnBool<T> : ActionTask
    {
        public BBParameter<bool> boolVariable;   
        public BBParameter<T> falseValue;
        public BBParameter<T> trueValue;
        [BlackboardOnly]
        public BBParameter<T> setTo;
        protected override string info
        {
            get
            {
                return string.Format("{0} setTo {1}", setTo, boolVariable.value ? trueValue : falseValue);
            }
        }
        protected override void OnExecute(){
            setTo.value = boolVariable.value ? trueValue.value : falseValue.value;
            EndAction();
        }
    }
}