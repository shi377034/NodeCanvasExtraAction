using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("RectTransform")]
    public class RectTransformGetAnchorMinAndMax : ActionTask<RectTransform>
    {
        [BlackboardOnly]
        public BBParameter<Vector2> anchorMax;
        [BlackboardOnly]
        public BBParameter<Vector2> anchorMin;
        [BlackboardOnly]
        public BBParameter<float> xMax;
        [BlackboardOnly]
        public BBParameter<float> yMax;
        [BlackboardOnly]
        public BBParameter<float> xMin;
        [BlackboardOnly]
        public BBParameter<float> yMin;

        protected override void OnExecute()
        {
            anchorMax.value = agent.anchorMax;
            anchorMin.value = agent.anchorMin;
            xMax.value = agent.anchorMax.x;
            yMax.value = agent.anchorMax.y;
            xMin.value = agent.anchorMin.x;
            yMin.value = agent.anchorMin.y;
            EndAction();
        }      
    }
}