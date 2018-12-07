using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("RenderSettings")]
    public class SetFlareStrength : ActionTask
    {
        public BBParameter<float> flareStrength = 0.2f;
        protected override void OnExecute()
        {
            RenderSettings.flareStrength = flareStrength.value;
            EndAction();
        }
    }
}