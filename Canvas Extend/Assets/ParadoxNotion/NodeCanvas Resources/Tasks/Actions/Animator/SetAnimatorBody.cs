using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{
    [Name("Set Body")]
    [Category("Animator")]
    [EventReceiver("OnAnimatorIK")]
    public class SetAnimatorBody : ActionTask<Animator>
    {
        public BBParameter<GameObject> target;
        public BBParameter<Vector3> position;
        public BBParameter<Vector3> rotation;
        public void OnAnimatorIK()
        {
            if(target.value != null)
            {
                agent.bodyPosition = target.value.transform.position + position.value;
                agent.bodyRotation = target.value.transform.rotation * Quaternion.Euler(rotation.value);
            }else
            {
                agent.bodyPosition = position.value;
                agent.bodyRotation = Quaternion.Euler(rotation.value);
            }
            EndAction();
        }
    }
}
