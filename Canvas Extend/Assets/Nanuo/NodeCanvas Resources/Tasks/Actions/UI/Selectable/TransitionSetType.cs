using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Set Transition")]
    [Category("UI/Selectable")]
    public class TransitionSetType : ActionTask<Selectable>
    {
        public BBParameter<Selectable.Transition> transition;
        protected override void OnExecute()
        {
            agent.transition = transition.value;
            EndAction();
        }
    }
}