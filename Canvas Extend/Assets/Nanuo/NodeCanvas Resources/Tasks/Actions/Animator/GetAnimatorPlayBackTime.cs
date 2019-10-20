using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{
    [Name("Get PlayBackTime")]
    [Category("Animator")]
    public class GetAnimatorPlayBackTime : ActionTask<Animator>
    {
        [BlackboardOnly]
        public BBParameter<float> playBackTime;
        protected override string info {
            get
            {
                return string.Format("{0} = playbackTime", playBackTime);
            }
        }
        protected override void OnExecute()
        {
            playBackTime.value = agent.playbackTime;
            EndAction();
        }
    }
}