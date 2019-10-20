using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;

namespace NodeCanvas.Tasks.Conditions
{
    [Category("Logic")]
    public class VariableChanged<T> : ConditionTask
    {
        public BBParameter<T> variable;
        T previousValue;
        protected override string OnInit()
        {
            previousValue = variable.value;
            return null;
        }
        protected override bool OnCheck()
        {
            if (!variable.value.Equals(previousValue))
            {
                previousValue = variable.value;
                return true;
            }
            return false;
        }
    }
}