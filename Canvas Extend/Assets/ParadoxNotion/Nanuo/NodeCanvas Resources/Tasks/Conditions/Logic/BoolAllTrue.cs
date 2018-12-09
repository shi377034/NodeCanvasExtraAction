using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;

namespace NodeCanvas.Tasks.Conditions{

	[Category("Logic")]
	public class BoolAllTrue : ConditionTask{
        public BBParameter<List<bool>> boolVariables;

        protected override bool OnCheck(){
            if (boolVariables.value.Count <= 0) return false;
            var allTrue = true;
            for (var i = 0; i < boolVariables.value.Count; i++)
            {
                if (!boolVariables.value[i])
                {
                    allTrue = false;
                    break;
                }
            }
            return allTrue;					
		}
	}
}