using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions{
	[Category("Character")]
	public class ControllerSimpleMove : ActionTask<CharacterController>
    {
        public BBParameter<Vector3> moveVector;
        public BBParameter<float> speed;
        public BBParameter<Space> space;

        protected override void OnExecute(){
            var move = space.value == Space.World ? moveVector.value : agent.transform.TransformDirection(moveVector.value);
            agent.SimpleMove(move * speed.value);
            EndAction();
        }
    }
}