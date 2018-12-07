using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{
    [Name("Set ApplyRootMotion")]
    [Category("Animator")]
    public class SetAnimatorApplyRootMotion : ActionTask<Animator>
    {
        public BBParameter<bool> applyRootMotion;
        protected override string info
        {
            get
            {
                return "Animator.applyRootMotion = " + applyRootMotion;
            }
        }
        protected override void OnExecute()
        {
            agent.applyRootMotion = applyRootMotion.value;
            EndAction();
        }
    }
}
