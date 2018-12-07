using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Get ScaleFactor")]
    [Category("UI/CanvasScaler")]
    public class CanvasScalerGetScaleFactor : ActionTask<CanvasScaler>
    {
        [BlackboardOnly]
        public BBParameter<float> scaleFactor;
        protected override void OnExecute()
        {
            scaleFactor.value = agent.scaleFactor;
            EndAction();
        }
    }
}