using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Name("Set Mute")]
    [Category("Audio")]
    public class AudioMute : ActionTask<AudioSource>
    {
        public BBParameter<bool> mute;

        protected override string info
        {
            get { return "Audio.Mute = " + mute; }
        }

        protected override void OnExecute()
        {
            agent.mute = mute.value;
            EndAction();
        }
    }
}