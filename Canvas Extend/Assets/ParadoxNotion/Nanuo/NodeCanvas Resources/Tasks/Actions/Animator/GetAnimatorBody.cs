using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{
    [Name("Get Body")]
    [Category("Animator")]
    [EventReceiver("OnAnimatorIK")]
    public class GetAnimatorBody : ActionTask<Animator>
    {
        [BlackboardOnly]
        public BBParameter<Vector3> bodyPosition;
        [BlackboardOnly]
        public BBParameter<Quaternion> bodyRotation;
        public BBParameter<GameObject> bodyGameObject;
        public BBParameter<bool> everyFrame;
        private Transform _transform;
        public void OnAnimatorIK()
        {
            if (bodyGameObject.value != null)
            {
                _transform = bodyGameObject.value.transform;
            }
            DoGetBodyPosition();
            if (!everyFrame.value)
                EndAction();
        }
        void DoGetBodyPosition()
        {
            bodyPosition.value = agent.bodyPosition;
            bodyRotation.value = agent.bodyRotation;

            if (_transform != null)
            {
                _transform.position = agent.bodyPosition;
                _transform.rotation = agent.bodyRotation;
            }
        }
    }
}
