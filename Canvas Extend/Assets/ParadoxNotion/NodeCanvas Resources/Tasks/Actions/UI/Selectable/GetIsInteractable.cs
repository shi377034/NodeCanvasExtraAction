using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Get Interactable")]
    [Category("UI/Selectable")]
    public class GetIsInteractable : ActionTask<Selectable>
    {
        [BlackboardOnly]
        public BBParameter<bool> interactable;

        protected override void OnExecute()
        {
            interactable.value = agent.interactable;
            EndAction();
        }

    }
}