using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions{

	[Category("Character")]
    [EventReceiver("OnControllerColliderHit")]
    public class CheckControllerColliderHit : ConditionTask<CharacterController> {
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

		protected override bool OnCheck(){
            return false;
		}
        public void OnControllerColliderHit(ControllerColliderHit hit)
        {
            gameObjectHit.value = hit.gameObject;
            contactPoint.value = hit.point;
            contactNormal.value = hit.normal;
            moveDirection.value = hit.moveDirection;
            moveLength.value = hit.moveLength;
            physicsMaterialName.value = hit.collider.material.name;
            YieldReturn(true);
        }
    }
}