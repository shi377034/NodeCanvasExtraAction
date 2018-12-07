using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{
    [Name("StartRecording")]
    [Category("Animator")]
    public class AnimatorStartRecording : ActionTask<Animator>
    {
        public BBParameter<int> frameCount;
        protected override void OnExecute()
        {
            agent.StartRecording(frameCount.value);
            EndAction();
        }
    }
}