using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace NodeCanvas.Tasks.Conditions{

	[Category("UGUI")]
	public class IsInteractable : ConditionTask<Selectable>
    {
        public BBParameter<bool> value;

        protected override string info
        {
            get { return string.Format("IsInteractable == {0}", value); }
        }

        protected override bool OnCheck()
        {

            return agent.IsInteractable() == value.value;
        }
    }
}