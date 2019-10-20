using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{
    [Name("Get Root")]
    [Category("Animator")]
    public class GetAnimatorRoot : ActionTask<Animator>
    {
        [BlackboardOnly]
        public BBParameter<Vector3> rootPosition;
        [BlackboardOnly]
        public BBParameter<Quaternion> rootRotation;
        public BBParameter<GameObject> bodyGameObject;
        protected override void OnExecute()
        {
            rootPosition.value = agent.rootPosition;
            rootRotation.value = agent.rootRotation;
            if(bodyGameObject.value != null)
            {
                bodyGameObject.value.transform.position = agent.rootPosition;
                bodyGameObject.value.transform.rotation = agent.rootRotation;
            }
            EndAction();
        }
    }
}