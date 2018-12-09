using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions{

	[Name("Set IK Goal")]
	[Category("Animator")]
	[EventReceiver("OnAnimatorIK")]
	public class MecanimSetIKGoal : ActionTask<Animator> {

		public AvatarIKGoal IKGoal;
		[RequiredField]
		public BBParameter<GameObject> goal;
        public BBParameter<Vector3> position;
        public BBParameter<Vector3> rotation;
        public BBParameter<float> positionWeight;
        public BBParameter<float> rotationWeight;

        protected override string info{
			get{return "Set '" + IKGoal + "' " + goal;}
		}

		public void OnAnimatorIK(){
            agent.SetIKPosition(IKGoal, goal.value.transform.position);
            agent.SetIKRotation(IKGoal, goal.value.transform.rotation * Quaternion.Euler(rotation.value));

            agent.SetIKPositionWeight(IKGoal, positionWeight.value);
            agent.SetIKRotationWeight(IKGoal, rotationWeight.value);
			EndAction();
		}
	}
}