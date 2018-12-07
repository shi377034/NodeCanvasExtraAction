using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;

namespace NodeCanvas.Tasks.Actions
{
    [Category("Audio")]
    public class AudioRandomSound : ActionTask<AudioSource>
    {
        public BBParameter<List<AudioClip>> audioClips;
        [SliderField(0,1f)]
        public BBParameter<List<float>> weights;
        [SliderField(0, 1f)]
        public BBParameter<float> volume = 1f;
        private int randomIndex;
        private int lastIndex = -1;
        protected override string info
        {
            get { return "Audio Play Random Sound"; }
        }

        protected override void OnExecute()
        {
            if(audioClips.value.Count >0)
            {
                do
                {
                    randomIndex = weights.value.RandomWeightedIndex();
                } while (randomIndex == lastIndex && randomIndex != -1);
                lastIndex = randomIndex;
                if(randomIndex != -1)
                {
                    AudioClip clip = audioClips.value[randomIndex];
                    if(clip != null)
                    {
                        agent.PlayOneShot(clip, volume.value);
                    }
                }
            }
            EndAction();
        }
    }
}