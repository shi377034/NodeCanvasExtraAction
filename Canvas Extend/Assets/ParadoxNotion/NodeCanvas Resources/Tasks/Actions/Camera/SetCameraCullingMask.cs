using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions{
	[Category("Camera")]
	public class SetCameraCullingMask : ActionTask<Camera>
    {
        public BBParameter<LayerMask> cullingMask;
        public BBParameter<bool> invertMask;
        protected override void OnExecute(){
            int layermask = cullingMask.value;
            if(invertMask.value)
            {
                layermask = ~layermask;
            }
            agent.cullingMask = layermask;
            EndAction();
        }
    }
}