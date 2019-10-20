using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Category("Transform")]
    public class SmoothLookAtDirection : ActionTask<Transform>
    {
        public BBParameter<Vector3> targetDirection;
        public BBParameter<float> minMagnitude;
        public BBParameter<Vector3> upVector;
        public BBParameter<bool> keepVertical = true;
        public BBParameter<float> speed = 5f;
        public BBParameter<string> finishEvent;
        GameObject previousGo; // track game object so we can re-initialize when it changes.
        Quaternion lastRotation;
        Quaternion desiredRotation;
        protected override void OnExecute()
        {
            DoSmoothLookAtDirection();
        }
        void DoSmoothLookAtDirection()
        {
            var go = agent.gameObject;

            // re-initialize if game object has changed

            if (previousGo != go)
            {
                lastRotation = go.transform.rotation;
                desiredRotation = lastRotation;
                previousGo = go;
            }

            // desired direction

            var diff = targetDirection.value;

            if (keepVertical.value)
            {
                diff.y = 0;
            }

            var reachedTarget = false;
            if (diff.sqrMagnitude > minMagnitude.value)
            {
                desiredRotation = Quaternion.LookRotation(diff, upVector.value);
            }
            else
            {
                reachedTarget = true;
            }

            lastRotation = Quaternion.Slerp(lastRotation, desiredRotation, speed.value * Time.deltaTime);
            go.transform.rotation = lastRotation;

            if (reachedTarget)
            {
                this.SendEvent(finishEvent.value);
                EndAction();
            }
        }
    }
}