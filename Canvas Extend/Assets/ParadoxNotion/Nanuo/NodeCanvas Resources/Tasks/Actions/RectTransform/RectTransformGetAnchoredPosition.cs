using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("RectTransform")]
    public class RectTransformGetAnchoredPosition : ActionTask<RectTransform>
    {
        [BlackboardOnly]
        public BBParameter<Vector2> position;
        [BlackboardOnly]
        public BBParameter<float> x;
        [BlackboardOnly]
        public BBParameter<float> y;

        protected override void OnExecute()
        {
            position.value = agent.anchoredPosition;
            x.value = agent.anchoredPosition.x;
            y.value = agent.anchoredPosition.y;
            EndAction();
        }      
    }
}