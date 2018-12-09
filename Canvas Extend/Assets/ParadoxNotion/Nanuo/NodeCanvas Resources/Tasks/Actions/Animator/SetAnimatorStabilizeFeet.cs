using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{
    [Name("Set StabilizeFeet")]
    [Category("Animator")]
    public class SetAnimatorStabilizeFeet : ActionTask<Animator>
    {
        public BBParameter<bool> stabilizeFeet;
        protected override string info
        {
            get
            {
                return "Animator.stabilizeFeet = " + stabilizeFeet;
            }
        }
        protected override void OnExecute()
        {
            agent.stabilizeFeet = stabilizeFeet.value;
            EndAction();
        }
    }
}