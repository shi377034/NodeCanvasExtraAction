using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("RectTransform")]
    public class RectTransformGetSizeDelta : ActionTask<RectTransform>
    {
        [BlackboardOnly]
        public BBParameter<Vector2> sizeDelta;
        [BlackboardOnly]
        public BBParameter<float> width;
        [BlackboardOnly]
        public BBParameter<float> height;

        protected override void OnExecute()
        {
            sizeDelta.value = agent.sizeDelta;
            width.value = agent.sizeDelta.x;
            height.value = agent.sizeDelta.y;

            EndAction();
        }      
    }
}