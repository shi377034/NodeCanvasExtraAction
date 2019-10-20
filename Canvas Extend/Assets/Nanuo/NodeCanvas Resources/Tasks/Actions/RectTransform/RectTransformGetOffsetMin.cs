using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("RectTransform")]
    public class RectTransformGetOffsetMin : ActionTask<RectTransform>
    {
        [BlackboardOnly]
        public BBParameter<Vector2> offsetMin;
        [BlackboardOnly]
        public BBParameter<float> x;
        [BlackboardOnly]
        public BBParameter<float> y;

        protected override void OnExecute()
        {
            offsetMin.value = agent.offsetMin;
            x.value = agent.offsetMin.x;
            y.value = agent.offsetMin.y;

            EndAction();
        }      
    }
}