using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{
    [Name("Set Pitch")]
    [Category("Audio")]
    public class SetAudioPitch : ActionTask<AudioSource>
    {
        public BBParameter<float> pitch;
        protected override string info
        {
            get { return "Audio.pitch = " + pitch.ToString(); }
        }

        protected override void OnExecute()
        {
            agent.pitch = pitch.value;
            EndAction();
        }
    }
}