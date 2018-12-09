using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{
    [Name("StopPlayback")]
    [Category("Animator")]
    public class AnimatorStopPlayback : ActionTask<Animator>
    {

        protected override void OnExecute()
        {
            agent.StopPlayback();
            EndAction();
        }
    }
}