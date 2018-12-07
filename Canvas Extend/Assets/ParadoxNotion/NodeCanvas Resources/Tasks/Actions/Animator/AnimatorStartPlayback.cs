using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{
    [Name("StartPlayback")]
    [Category("Animator")]
    public class AnimatorStartPlayback : ActionTask<Animator>
    {
        protected override void OnExecute()
        {
            agent.StartPlayback();
            EndAction();
        }
    }
}