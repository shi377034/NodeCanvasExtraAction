using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Name("Set Clip")]
    [Category("Audio")]
    public class SetAudioClip : ActionTask<AudioSource>
    {
        public BBParameter<AudioClip> audioClip;
        protected override string info
        {
            get { return "Audio.Clip = " + audioClip.ToString(); }
        }

        protected override void OnExecute()
        {
            agent.clip = audioClip.value;
            EndAction();
        }
    }
}