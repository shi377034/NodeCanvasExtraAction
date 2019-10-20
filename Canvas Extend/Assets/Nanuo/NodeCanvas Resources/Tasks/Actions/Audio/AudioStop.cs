using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Name("Stop")]
    [Category("Audio")]
    public class AudioStop : ActionTask<AudioSource>
    {
        protected override string info
        {
            get { return "Audio Stop"; }
        }

        protected override void OnExecute()
        {
            agent.Stop();
            EndAction();
        }
    }
}