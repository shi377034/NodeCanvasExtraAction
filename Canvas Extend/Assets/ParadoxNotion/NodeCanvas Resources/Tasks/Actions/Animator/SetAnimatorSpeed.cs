using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{
    [Name("Set Speed")]
    [Category("Animator")]
    public class SetAnimatorSpeed : ActionTask<Animator>
    {
        public BBParameter<float> speed;
        protected override string info
        {
            get
            {
                return "Animator.speed = " + speed;
            }
        }
        protected override void OnExecute()
        {
            agent.speed = speed.value;
            EndAction();
        }
    }
}