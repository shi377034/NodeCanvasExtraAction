using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{
    [Name("Quit")]
    [Category("Application")]
    public class ApplicationQuit : ActionTask
    {

        protected override void OnExecute()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
            EndAction();
        }
    }
}
