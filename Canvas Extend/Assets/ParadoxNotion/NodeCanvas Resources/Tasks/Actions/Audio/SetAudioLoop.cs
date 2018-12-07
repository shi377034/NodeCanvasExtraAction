using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{
    [Name("Set Loop")]
    [Category("Audio")]
    public class SetAudioLoop : ActionTask<AudioSource>
    {
        public BBParameter<bool> loop;
        protected override string info
        {
            get { return "Audio.loop = " + loop.ToString(); }
        }

        protected override void OnExecute()
        {
            agent.loop = loop.value;
            EndAction();
        }
    }
}