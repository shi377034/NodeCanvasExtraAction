using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("RenderSettings")]
    public class EnableFog : ActionTask
    {
        public BBParameter<bool> enableFog;
        protected override void OnExecute()
        {
            RenderSettings.fog = enableFog.value;
            EndAction();
        }
    }
}