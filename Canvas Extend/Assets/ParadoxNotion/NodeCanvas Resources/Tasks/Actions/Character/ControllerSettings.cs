using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions{
	[Category("Character")]
	public class ControllerSettings : ActionTask<CharacterController>
    {
        public BBParameter<float> height;
        public BBParameter<float> radius;
        public BBParameter<float> slopeLimit;
        public BBParameter<float> stepOffset;
        public BBParameter<Vector3> center;
        public BBParameter<bool> detectCollisions;
        protected override void OnExecute(){
            agent.height = height.value;
            agent.radius = radius.value;
            agent.slopeLimit = slopeLimit.value;
            agent.stepOffset = stepOffset.value;
            agent.center = center.value;
            agent.detectCollisions = detectCollisions.value;
            EndAction();
        }
    }
}