using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("RectTransform")]
    public class RectTransformGetPivot : ActionTask<RectTransform>
    {
        [BlackboardOnly]
        public BBParameter<Vector2> pivot;
        [BlackboardOnly]
        public BBParameter<float> x;
        [BlackboardOnly]
        public BBParameter<float> y;

        protected override void OnExecute()
        {
            pivot.value = agent.pivot;
            x.value = agent.pivot.x;
            y.value = agent.pivot.y;

            EndAction();
        }      
    }
}