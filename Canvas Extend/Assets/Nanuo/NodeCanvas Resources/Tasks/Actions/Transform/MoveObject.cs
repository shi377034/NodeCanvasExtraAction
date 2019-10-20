using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using DG.Tweening;

namespace NodeCanvas.Tasks.Actions
{
    [Category("Transform")]
    public class MoveObject : ActionTask<Transform>
    {
        public BBParameter<GameObject> destination;
        public BBParameter<Vector3> destinationPosition;
        public Space space = Space.World;
        public BBParameter<float> duration = 0.25f;
        public BBParameter<bool> snapping = false;
        public BBParameter<Ease> ease = Ease.Linear;
        public BBParameter<float> delay = 0f;
        public BBParameter<bool> waitFinish;
        public BBParameter<string> finishEvent;
        private Vector3 toVector;
        protected override void OnExecute()
        {
            toVector = destination.value == null ? destinationPosition.value : destination.value.transform.position;
            Tweener tween = null;
            switch (space)
            {
                case Space.World:
                    tween = agent.DOMove(toVector, duration.value, snapping.value);
                    break;
                case Space.Self:
                    tween = agent.DOLocalMove(toVector, duration.value, snapping.value);
                    break;
            }
            tween.SetEase(ease.value)
                 .SetDelay(delay.value);
            if (waitFinish.value)
            {
                tween.OnComplete(() =>
                {
                    this.SendEvent(finishEvent.value);
                    EndAction();
                });
            }
            else
            {
                EndAction();
            }
        }
    }
}