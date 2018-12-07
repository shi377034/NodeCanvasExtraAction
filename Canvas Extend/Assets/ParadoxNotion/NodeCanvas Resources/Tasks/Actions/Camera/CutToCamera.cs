using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions{

	[Category("Camera")]
	public class CutToCamera : ActionTask<Camera>
    {
        public BBParameter<bool> makeMainCamera;
        private Camera oldCamera;

        protected override void OnExecute(){
            oldCamera = Camera.main;
            SwitchCamera(Camera.main, agent);
            if (makeMainCamera.value)
            {
                agent.tag = "MainCamera";
            }
            EndAction();
        }
        private static void SwitchCamera(Camera camera1, Camera camera2)
        {
            if (camera1 != null)
            {
                camera1.enabled = false;
            }

            if (camera2 != null)
            {
                camera2.enabled = true;
            }
        }
    }
}