using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{
    [Name("Get Target")]
    [Category("Animator")]
    public class GetAnimatorTarget : ActionTask<Animator>
    {
        [BlackboardOnly]
        public BBParameter<Vector3> targetPosition;
        [BlackboardOnly]
        public BBParameter<Quaternion> targetRotation;
        public BBParameter<GameObject> targetGameObject;
        protected override void OnExecute()
        {
            targetPosition.value = agent.targetPosition;
            targetRotation.value = agent.targetRotation;
            if(targetGameObject.value != null)
            {
                targetGameObject.value.transform.position = agent.targetPosition;
                targetGameObject.value.transform.rotation = agent.targetRotation;
            }
            EndAction();
        }
    }
}