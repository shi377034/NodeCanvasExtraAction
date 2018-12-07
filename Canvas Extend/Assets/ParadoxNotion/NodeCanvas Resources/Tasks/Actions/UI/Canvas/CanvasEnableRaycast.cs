using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{
    [Name("EnableRaycast")]
    [Category("UI/Canvas")]
    public class CanvasEnableRaycast : ActionTask<CanvasRaycastFilterProxy>
    {
        public BBParameter<bool> enableRaycasting;
        protected override void OnExecute()
        {
            agent.RayCastingEnabled = enableRaycasting.value;
            EndAction();
        }
    }
}