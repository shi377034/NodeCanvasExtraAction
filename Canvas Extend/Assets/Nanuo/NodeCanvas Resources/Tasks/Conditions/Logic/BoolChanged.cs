using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;

namespace NodeCanvas.Tasks.Conditions
{

    [Category("Logic")]
    public class BoolChanged : ConditionTask
    {
        public BBParameter<bool> boolVariables;
        bool previousValue;
        protected override string OnInit()
        {
            previousValue = boolVariables.value;
            return null;
        }
        protected override bool OnCheck()
        {
            if (boolVariables.value != previousValue)
            {
                previousValue = boolVariables.value;
                return true;
            }
            return false;
        }
    }
}