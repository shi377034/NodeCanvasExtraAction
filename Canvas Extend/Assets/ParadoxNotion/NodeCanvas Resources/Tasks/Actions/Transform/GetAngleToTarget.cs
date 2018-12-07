using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Category("Transform")]
    public class GetAngleToTarget : ActionTask<Transform>
    {
        public BBParameter<Transform> targetObject;
        public BBParameter<Vector3> targetPosition;
        public BBParameter<bool> ignoreHeight;
        [BlackboardOnly]
        public BBParameter<float> angle;
        [BlackboardOnly]
        public BBParameter<float> signedAngle;
        protected override void OnExecute()
        {
            DoGetAngleToTarget();
            EndAction();
        }

        void DoGetAngleToTarget()
        {
            var go = agent.gameObject;

            var goTarget = targetObject.value;

            Vector3 targetPos;
            if (goTarget != null)
            {
                targetPos = goTarget.transform.TransformPoint(targetPosition.value);
            }
            else
            {
                targetPos = targetPosition.value;
            }

            if (ignoreHeight.value)
            {
                targetPos.y = go.transform.position.y;
            }

            var targetDir = targetPos - go.transform.position;

            angle.value = Vector3.Angle(targetDir, go.transform.forward);
            signedAngle.value = Vector3.SignedAngle(targetDir, go.transform.forward, go.transform.up);
        }
    }
}