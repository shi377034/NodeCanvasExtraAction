using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{

    [Name("Set ScaleFactor")]
    [Category("UI/CanvasScaler")]
    public class CanvasScalerSetScaleFactor : ActionTask<CanvasScaler>
    {
        public BBParameter<float> scaleFactor;
        protected override void OnExecute()
        {
            agent.scaleFactor = scaleFactor.value;
            EndAction();
        }
    }
}