using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions{
	[Category("Character")]
    [EventReceiver("OnControllerColliderHit")]
	public class GetControllerHitInfo : ActionTask<CharacterController>
    {
        [BlackboardOnly]
        public BBParameter<GameObject> gameObjectHit;
        [BlackboardOnly]
        public BBParameter<Vector3> contactPoint;
        [BlackboardOnly]
        public BBParameter<Vector3> contactNormal;
        [BlackboardOnly]
        public BBParameter<Vector3> moveDirection;
        [BlackboardOnly]
        public BBParameter<float> moveLength;
        [BlackboardOnly]
        public BBParameter<string> physicsMaterialName;
        private ControllerColliderHit ControllerCollider;
        protected override void OnExecute(){
            if(ControllerCollider != null)
            {
                gameObjectHit.value = ControllerCollider.gameObject;
                contactPoint.value = ControllerCollider.point;
                contactNormal.value = ControllerCollider.normal;
                moveDirection.value = ControllerCollider.moveDirection;
                moveLength.value = ControllerCollider.moveLength;
                physicsMaterialName.value = ControllerCollider.collider.material.name;
            }  
            EndAction();
        }
        public void OnControllerColliderHit(ControllerColliderHit hit)
        {
            ControllerCollider = hit;
        }
    }
}