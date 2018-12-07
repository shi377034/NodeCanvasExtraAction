using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("RenderSettings")]
    public class SetFogColor : ActionTask
    {
        public BBParameter<Color> fogColor = Color.white;
        protected override void OnExecute()
        {
            RenderSettings.fogColor = fogColor.value;
            EndAction();
        }
    }
}