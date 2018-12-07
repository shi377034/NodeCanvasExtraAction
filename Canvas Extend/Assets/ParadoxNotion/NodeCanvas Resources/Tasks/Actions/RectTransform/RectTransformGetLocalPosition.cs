using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("RectTransform")]
    public class RectTransformGetLocalPosition : ActionTask<RectTransform>
    {
        public enum LocalPositionReference { Anchor, CenterPosition };
        public LocalPositionReference reference;
        [BlackboardOnly]
        public BBParameter<Vector3> position;
        [BlackboardOnly]
        public BBParameter<float> x;
        [BlackboardOnly]
        public BBParameter<float> y;
        [BlackboardOnly]
        public BBParameter<float> z;

        protected override void OnExecute()
        {
            Vector3 _pos = agent.localPosition;

            if (reference == LocalPositionReference.CenterPosition)
            {
                _pos.x += agent.rect.center.x;
                _pos.y += agent.rect.center.y;
            }

            position.value = _pos;

            x.value = _pos.x;
            y.value = _pos.y;
            z.value = _pos.z;
            EndAction();
        }      
    }
}