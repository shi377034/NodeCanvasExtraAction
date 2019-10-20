using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{
    [Name("RunInBackground")]
    [Category("Application")]
    public class ApplicationRunInBackground : ActionTask
    {
        public BBParameter<bool> runInBackground;
        protected override void OnExecute()
        {
            Application.runInBackground = runInBackground.value;
            EndAction();
        }

    }
}