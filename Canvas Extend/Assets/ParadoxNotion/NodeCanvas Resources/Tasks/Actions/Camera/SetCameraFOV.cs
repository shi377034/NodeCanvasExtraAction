using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions{
	[Category("Camera")]
	public class SetCameraFOV : ActionTask<Camera>
    {
        public BBParameter<float> fieldOfView;
        protected override void OnExecute(){
            agent.fieldOfView = fieldOfView.value;
            EndAction();
        }
    }
}