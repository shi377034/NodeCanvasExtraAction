using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Name("Play")]
    [Category("Audio")]
    public class AudioPlay : ActionTask<AudioSource>
    {
        [SliderField(0,1f)]
        public BBParameter<float> volume = 1f;
        public BBParameter<AudioClip> oneShotClip;
        public BBParameter<bool> WaitForEndOfClip;
        protected override string info
        {
            get { return "PlayAudio " + oneShotClip.ToString(); }
        }

        protected override void OnExecute()
        {
            if(oneShotClip.value == null)
            {
                agent.volume = volume.value;
                agent.Play();
            }
            else
            {
                agent.PlayOneShot(oneShotClip.value, volume.value);
            }
            if(!WaitForEndOfClip.value)
                EndAction();
        }
        protected override void OnUpdate()
        {
            if(!agent.isPlaying)
            {
                EndAction();
            }
        }
    }
}