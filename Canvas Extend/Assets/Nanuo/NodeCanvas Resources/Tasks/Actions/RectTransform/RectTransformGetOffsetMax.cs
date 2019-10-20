using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("RectTransform")]
    public class RectTransformGetOffsetMax : ActionTask<RectTransform>
    {
        [BlackboardOnly]
        public BBParameter<Vector2> offsetMax;
        [BlackboardOnly]
        public BBParameter<float> x;
        [BlackboardOnly]
        public BBParameter<float> y;

        protected override void OnExecute()
        {
            offsetMax.value = agent.offsetMax;
            x.value = agent.offsetMax.x;
            y.value = agent.offsetMax.y;

            EndAction();
        }      
    }
}