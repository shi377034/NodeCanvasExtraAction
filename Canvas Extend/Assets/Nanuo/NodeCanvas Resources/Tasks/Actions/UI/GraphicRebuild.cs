using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Rebuild")]
    [Category("UI/Graphic")]
    public class GraphicRebuild : ActionTask<Graphic>
    {
        public BBParameter<CanvasUpdate> canvasUpdate = CanvasUpdate.LatePreRender;

        protected override void OnExecute()
        {
            agent.Rebuild(canvasUpdate.value);
            EndAction();
        }
    }
}