using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Name("Pause")]
    [Category("Audio")]
    public class AudioPause : ActionTask<AudioSource>
    {
        protected override string info
        {
            get { return "Audio Pause"; }
        }

        protected override void OnExecute()
        {
            agent.Pause();
            EndAction();
        }
    }
}