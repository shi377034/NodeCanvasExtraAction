using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{
    [Name("StopRecording")]
    [Category("Animator")]
    public class AnimatorStopRecording : ActionTask<Animator>
    {
        [BlackboardOnly]
        public BBParameter<float> recorderStartTime;
        [BlackboardOnly]
        public BBParameter<float> recorderStopTime;
        protected override void OnExecute()
        {
            agent.StopRecording();
            recorderStartTime.value = agent.recorderStartTime;
            recorderStopTime.value = agent.recorderStopTime;
            EndAction();
        }
    }
}