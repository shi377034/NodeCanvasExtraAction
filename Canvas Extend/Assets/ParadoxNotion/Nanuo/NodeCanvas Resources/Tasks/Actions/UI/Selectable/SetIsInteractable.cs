using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Set Interactable")]
    [Category("UI/Selectable")]
    public class SetIsInteractable : ActionTask<Selectable>
    {
        public BBParameter<bool> interactable;

        protected override void OnExecute()
        {
            agent.interactable = interactable.value;
            EndAction();
        }
    }
}