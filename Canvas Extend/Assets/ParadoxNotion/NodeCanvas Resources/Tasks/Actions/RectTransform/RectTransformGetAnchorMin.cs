using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("RectTransform")]
    public class RectTransformGetAnchorMin : ActionTask<RectTransform>
    {
        [BlackboardOnly]
        public BBParameter<Vector2> anchorMin;
        [BlackboardOnly]
        public BBParameter<float> x;
        [BlackboardOnly]
        public BBParameter<float> y;

        protected override void OnExecute()
        {
            anchorMin.value = agent.anchorMin;
            x.value = agent.anchorMin.x;
            y.value = agent.anchorMin.y;
            EndAction();
        }      
    }
}