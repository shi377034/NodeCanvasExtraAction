using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using DG.Tweening;

namespace NodeCanvas.Tasks.Actions
{
    [Name("MoveTowards")]
    [Category("Transform")]
    public class MoveTowardsSuper : ActionTask<Transform>
    {
        public BBParameter<GameObject> targetObject;
        public BBParameter<Vector3> targetPosition;
        public BBParameter<bool> ignoreVertical;
        [SliderField(0,20f)]
        public BBParameter<float> maxSpeed = 10f;
        [SliderField(0, 5f)]
        public BBParameter<float> finishDistance = 1f;
        public BBParameter<string> finishEvent;
        private GameObject go;
        private GameObject goTarget;
        private Vector3 targetPos;
        private Vector3 targetPosWithVertical;
        protected override void OnUpdate()
        {
            DoMoveTowards();
        }
        void DoMoveTowards()
        {
            if (!UpdateTargetPos())
            {
                return;
            }

            go.transform.position = Vector3.MoveTowards(go.transform.position, targetPos, maxSpeed.value * Time.deltaTime);

            var distance = (go.transform.position - targetPos).magnitude;
            if (distance < finishDistance.value)
            {
                this.SendEvent(finishEvent.value);
                EndAction();
            }
        }
        public bool UpdateTargetPos()
        {
            go = agent.gameObject;
            goTarget = targetObject.value;

            if (goTarget != null)
            {
                targetPos = goTarget.transform.TransformPoint(targetPosition.value);
            }
            else
            {
                targetPos = targetPosition.value;
            }

            targetPosWithVertical = targetPos;

            if (ignoreVertical.value)
            {
                targetPos.y = go.transform.position.y;
            }

            return true;
        }

        public Vector3 GetTargetPos()
        {
            return targetPos;
        }

        public Vector3 GetTargetPosWithVertical()
        {
            return targetPosWithVertical;
        }
    }
}