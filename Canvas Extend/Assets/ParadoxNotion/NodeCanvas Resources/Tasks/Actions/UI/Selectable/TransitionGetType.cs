using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Get Transition")]
    [Category("UI/Selectable")]
    public class TransitionGetType : ActionTask<Selectable>
    {
        [BlackboardOnly]
        public BBParameter<Selectable.Transition> transition;
        protected override void OnExecute()
        {
            transition.value = agent.transition;
            EndAction();
        }
    }
}