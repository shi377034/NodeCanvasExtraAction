using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("RectTransform")]
    public class RectTransformGetAnchorMax : ActionTask<RectTransform>
    {
        [BlackboardOnly]
        public BBParameter<Vector2> anchorMax;
        [BlackboardOnly]
        public BBParameter<float> x;
        [BlackboardOnly]
        public BBParameter<float> y;

        protected override void OnExecute()
        {
            anchorMax.value = agent.anchorMax;
            x.value = agent.anchorMax.x;
            y.value = agent.anchorMax.y;
            EndAction();
        }      
    }
}