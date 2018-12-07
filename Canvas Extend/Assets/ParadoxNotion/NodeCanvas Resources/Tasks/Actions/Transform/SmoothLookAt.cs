using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Category("Transform")]
    public class SmoothLookAt : ActionTask<Transform>
    {
        public BBParameter<GameObject> targetObject;
        public BBParameter<Vector3> targetPosition;
        public BBParameter<Vector3> upVector;
        public BBParameter<bool> keepVertical = true;
        [SliderField(0.5f,15f)]
        public BBParameter<float> speed = 5f;
        public BBParameter<float> finishTolerance = 1f;
        public BBParameter<string> finishEvent;
        public BBParameter<bool> debug;

        private GameObject previousGo; // track game object so we can re-initialize when it changes.
        private Quaternion lastRotation;
        private Quaternion desiredRotation;
        protected override void OnExecute()
        {
            DoSmoothLookAt();
            EndAction();
        }
        void DoSmoothLookAt()
        {
            var go = agent.gameObject;

            var goTarget = targetObject.value;

            // re-initialize if game object has changed

            if (previousGo != go)
            {
                lastRotation = go.transform.rotation;
                desiredRotation = lastRotation;
                previousGo = go;
            }

            // desired look at position

            Vector3 lookAtPos;
            if (goTarget != null)
            {
                lookAtPos = goTarget.transform.TransformPoint(targetPosition.value);
            }
            else
            {
                lookAtPos = targetPosition.value;
            }

            if (keepVertical.value)
            {
                lookAtPos.y = go.transform.position.y;
            }

            // smooth look at

            var diff = lookAtPos - go.transform.position;
            if (diff != Vector3.zero && diff.sqrMagnitude > 0)
            {
                desiredRotation = Quaternion.LookRotation(diff,upVector.value);
            }

            lastRotation = Quaternion.Slerp(lastRotation, desiredRotation, speed.value * Time.deltaTime);
            go.transform.rotation = lastRotation;

            // debug line to target

            if (debug.value)
            {
                Debug.DrawLine(go.transform.position, lookAtPos, Color.grey);
            }

            var targetDir = lookAtPos - go.transform.position;
            var angle = Vector3.Angle(targetDir, go.transform.forward);

            if (Mathf.Abs(angle) <= finishTolerance.value)
            {
                this.SendEvent(finishEvent.value);
            }
        }
    }
}