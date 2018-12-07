using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{
    [Name("SetTarget")]
    [Category("Animator")]
    [EventReceiver("OnAnimatorMove")]
    public class SetAnimatorTarget : ActionTask<Animator>
    {
        public BBParameter<AvatarTarget> avatarTarget;
        public BBParameter<float> targetNormalizedTime;
        protected override string info
        {
            get
            {
                return string.Format("Animator.SetTarget({0},{1})", avatarTarget, targetNormalizedTime);
            }
        }
        public void OnAnimatorMove()
        {
            agent.SetTarget(avatarTarget.value, targetNormalizedTime.value);
            EndAction();
        }
    }
}