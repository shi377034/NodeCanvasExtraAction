using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("RenderSettings")]
    public class SetHaloStrength : ActionTask
    {
        public BBParameter<float> haloStrength = 0.5f;
        protected override void OnExecute()
        {
            RenderSettings.haloStrength = haloStrength.value;
            EndAction();
        }
    }
}