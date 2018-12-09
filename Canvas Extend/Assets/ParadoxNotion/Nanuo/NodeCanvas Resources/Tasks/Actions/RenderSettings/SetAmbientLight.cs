using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("RenderSettings")]
    public class SetAmbientLight : ActionTask
    {
        public BBParameter<Color> ambientColor = Color.gray;
        protected override void OnExecute()
        {
            RenderSettings.ambientLight = ambientColor.value;
            EndAction();
        }
    }
}