using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{
    [Name("Set Alpha")]
    [Category("UI/CanvasGroup")]
    public class CanvasGroupSetAlpha : ActionTask<UnityEngine.CanvasGroup>
    {
        [SliderField(0, 1f)]
        public BBParameter<float> alpha;
        protected override void OnExecute()
        {
            agent.alpha = alpha.value;
            EndAction();
        }
    }
}