using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("RectTransform")]
    public class RectTransformGetRect : ActionTask<RectTransform>
    {
        [BlackboardOnly]
        public BBParameter<Rect> rect;
        [BlackboardOnly]
        public BBParameter<float> x;
        [BlackboardOnly]
        public BBParameter<float> y;
        [BlackboardOnly]
        public BBParameter<float> width;
        [BlackboardOnly]
        public BBParameter<float> height;

        protected override void OnExecute()
        {
            rect.value = agent.rect;

            x.value = agent.rect.x;
            y.value = agent.rect.y;
            width.value = agent.rect.width;
            height.value = agent.rect.height;

            EndAction();
        }      
    }
}