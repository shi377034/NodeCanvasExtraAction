using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("RectTransform")]
    public class RectTransformPixelAdjustPoint : ActionTask<RectTransform>
    {
        [RequiredField]
        public BBParameter<Canvas> canvas;
        public BBParameter<Vector2> screenPoint;
        [BlackboardOnly]
        public BBParameter<Vector2> pixelPoint;

        protected override void OnExecute()
        {
            pixelPoint.value = RectTransformUtility.PixelAdjustPoint(screenPoint.value, agent, canvas.value);
            EndAction();
        }      
    }
}