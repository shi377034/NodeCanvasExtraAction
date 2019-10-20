using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{
    [Name("InterruptMatchTarget")]
    [Category("Animator")]
    public class AnimatorInterruptMatchTarget : ActionTask<Animator>
    {
        public BBParameter<bool> completeMatch;
        protected override void OnExecute()
        {
            agent.InterruptMatchTarget(completeMatch.value);
            EndAction();
        }
    }
}