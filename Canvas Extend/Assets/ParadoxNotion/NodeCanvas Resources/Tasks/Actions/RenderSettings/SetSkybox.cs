using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("RenderSettings")]
    public class SetSkybox : ActionTask
    {
        public BBParameter<Material> skybox;
        protected override void OnExecute()
        {
            RenderSettings.skybox = skybox.value;
            EndAction();
        }
    }
}