using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace NodeCanvas.Tasks.Conditions{

	[Category("UGUI")]
	public class CheckTransitionType : ConditionTask<Selectable>
    {
        public BBParameter<Selectable.Transition> value;
        protected override string info
        {
            get { return string.Format("transition == {0}", value); }
        }

        protected override bool OnCheck()
        { 
            return agent.transition == value.value;
        }
    }
}