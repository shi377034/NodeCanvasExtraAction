using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions{
	[Category("Character")]
	public class ControllerMove : ActionTask<CharacterController>
    {
        public BBParameter<Vector3> moveVector;
        public BBParameter<Space> space;
        public BBParameter<bool> perSecond;

        protected override void OnExecute(){
            var move = space.value == Space.World ? moveVector.value : agent.transform.TransformDirection(moveVector.value);
            if(perSecond.value)
            {
                agent.Move(move * Time.deltaTime);
            }else
            {
                agent.Move(move);
            }
            EndAction();
        }
    }
}