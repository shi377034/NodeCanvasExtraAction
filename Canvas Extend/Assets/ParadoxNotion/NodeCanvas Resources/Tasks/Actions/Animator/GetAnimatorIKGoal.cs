using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{
    [Name("Get IK Goal")]
    [Category("Animator")]
    public class GetAnimatorIKGoal : ActionTask<Animator>
    {
        public BBParameter<AvatarIKGoal> iKGoal;
        [BlackboardOnly]
        public BBParameter<GameObject> goal;
        [BlackboardOnly]
        public BBParameter<Vector3> position;
        [BlackboardOnly]
        public BBParameter<Quaternion> rotation;
        [BlackboardOnly]
        public BBParameter<float> positionWeight;
        [BlackboardOnly]
        public BBParameter<float> rotationWeight;
        protected override string info {
            get
            {
                return "Get " + iKGoal;
            }
        }
        protected override void OnExecute()
        {
            if(goal != null)
            {
                goal.value.transform.position = agent.GetIKPosition(iKGoal.value);
                goal.value.transform.rotation = agent.GetIKRotation(iKGoal.value);
            }
            position.value = agent.GetIKPosition(iKGoal.value);
            rotation.value = agent.GetIKRotation(iKGoal.value);
            positionWeight.value = agent.GetIKPositionWeight(iKGoal.value);
            rotationWeight.value = agent.GetIKRotationWeight(iKGoal.value);

            EndAction();
        }
    }
}