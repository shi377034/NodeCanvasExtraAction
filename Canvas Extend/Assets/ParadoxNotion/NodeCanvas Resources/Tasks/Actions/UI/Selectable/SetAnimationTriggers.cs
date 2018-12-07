using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Category("UI/Selectable")]
    public class SetAnimationTriggers : ActionTask<Selectable>
    {
        public BBParameter<string> normalTrigger;
        public BBParameter<string> highlightedTrigger;
        public BBParameter<string> pressedTrigger;
        public BBParameter<string> disabledTrigger;
        protected override void OnExecute()
        {
            var animationTriggers = agent.animationTriggers;
            animationTriggers.normalTrigger = normalTrigger.value;
            animationTriggers.highlightedTrigger = highlightedTrigger.value;
            animationTriggers.pressedTrigger = pressedTrigger.value;
            animationTriggers.disabledTrigger = disabledTrigger.value;
            agent.animationTriggers = animationTriggers;
            EndAction();
        }
    }
}