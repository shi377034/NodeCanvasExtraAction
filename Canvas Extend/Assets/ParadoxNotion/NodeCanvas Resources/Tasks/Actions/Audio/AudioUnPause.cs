using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Name("UnPause")]
    [Category("Audio")]
    public class AudioUnPause : ActionTask<AudioSource>
    {
        protected override string info
        {
            get { return "Audio UnPause"; }
        }

        protected override void OnExecute()
        {
            agent.UnPause();
            EndAction();
        }
    }
}