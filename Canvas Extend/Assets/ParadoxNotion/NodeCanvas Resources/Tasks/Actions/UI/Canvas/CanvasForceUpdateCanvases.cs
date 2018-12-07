using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{
    [Name("ForceUpdateCanvases")]
    [Category("UI/Canvas")]
    public class CanvasForceUpdateCanvases : ActionTask
    {
        protected override void OnExecute()
        {
            Canvas.ForceUpdateCanvases();
            EndAction();
        }
    }
}