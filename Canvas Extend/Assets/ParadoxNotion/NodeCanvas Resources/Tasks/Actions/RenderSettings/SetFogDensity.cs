using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("RenderSettings")]
    public class SetFogDensity : ActionTask
    {
        public BBParameter<float> fogDensity = 0.5f;
        protected override void OnExecute()
        {
            RenderSettings.fogDensity = fogDensity.value;
            EndAction();
        }
    }
}