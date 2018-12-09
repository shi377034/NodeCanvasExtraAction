using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("RectTransform")]
    public class RectTransformPixelAdjustRect : ActionTask<RectTransform>
    {
        [RequiredField]
        public BBParameter<Canvas> canvas;
        [BlackboardOnly]
        public BBParameter<Rect> pixelRect;

        protected override void OnExecute()
        {
            pixelRect.value = RectTransformUtility.PixelAdjustRect(agent, canvas.value);
            EndAction();
        }      
    }
}