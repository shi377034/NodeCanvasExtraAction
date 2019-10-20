using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{
    [Name("Set Volume")]
    [Category("Audio")]
    public class SetAudioVolume : ActionTask<AudioSource>
    {
        [SliderField(0,1f)]
        public BBParameter<float> volume;
        protected override string info
        {
            get { return "Audio.volume = " + volume.ToString(); }
        }

        protected override void OnExecute()
        {
            agent.volume = volume.value;
            EndAction();
        }
    }
}