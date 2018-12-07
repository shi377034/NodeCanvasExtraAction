using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{
    [Name("Set Properties")]
    [Category("UI/CanvasGroup")]
    public class CanvasGroupSetProperties : ActionTask<UnityEngine.CanvasGroup>
    {
        [SliderField(0,1f)]
        public BBParameter<float> alpha;
        public BBParameter<bool> interactable = true;
        public BBParameter<bool> blocksRaycasts = true;
        public BBParameter<bool> ignoreParentGroup;
        
        protected override void OnExecute()
        {
            agent.alpha = alpha.value;
            agent.interactable = interactable.value;
            agent.blocksRaycasts = blocksRaycasts.value;
            agent.ignoreParentGroups = ignoreParentGroup.value;
            EndAction();
        }
    }
}