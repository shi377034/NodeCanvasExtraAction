using NodeCanvas.Framework;
using ParadoxNotion.Design;
using ParadoxNotion.Services;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{

	[Category("Physics2D")]
    [EventReceiver("OnLateUpdate")]
	public class SmoothLookAt2d : ActionTask<GameObject>
    {
        public BBParameter<GameObject> targetObject;
        public BBParameter<Vector2> targetPosition2d;
        public BBParameter<float> rotationOffset;
        [SliderField(0.5f,15f)]
        public BBParameter<float> speed = 5f;
        public BBParameter<bool> debug;
        [Tooltip("If the angle to the target is less than this, send the Finish Event below. Measured in degrees.")]
        public BBParameter<float> finishTolerance = 1f;
        public BBParameter<string> finishEvent;
        private GameObject previousGo; 
        private Quaternion lastRotation;
        private Quaternion desiredRotation;

        protected override void OnExecute(){
            previousGo = null;
		}
        public void OnLateUpdate()
        {
            var goTarget = targetObject.value;

            // re-initialize if game object has changed

            if (previousGo != agent)
            {
                lastRotation = agent.transform.rotation;
                desiredRotation = lastRotation;
                previousGo = agent;
            }

            // desired look at position

            var lookAtPos = new Vector3(targetPosition2d.value.x, targetPosition2d.value.y, 0f);

            if (goTarget != null)
            {
                lookAtPos = goTarget.transform.position;
                var _offset = Vector3.zero;

                _offset.x = _offset.x + targetPosition2d.value.x;
                _offset.y = _offset.y + targetPosition2d.value.y;

                lookAtPos += goTarget.transform.TransformPoint(targetPosition2d.value);
            }

            var diff = lookAtPos - agent.transform.position;
            diff.Normalize();


            var rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            desiredRotation = Quaternion.Euler(0f, 0f, rot_z - rotationOffset.value);


            lastRotation = Quaternion.Slerp(lastRotation, desiredRotation, speed.value * Time.deltaTime);
            agent.transform.rotation = lastRotation;

            // debug line to target

            if (debug.value)
            {
                Debug.DrawLine(agent.transform.position, lookAtPos, Color.grey);
            }

            // send finish event?

            var angle = Vector3.Angle(desiredRotation.eulerAngles, lastRotation.eulerAngles);
            if (Mathf.Abs(angle) <= finishTolerance.value)
            {
                this.SendEvent(finishEvent.value);
                EndAction();
            }
        }
    }
}