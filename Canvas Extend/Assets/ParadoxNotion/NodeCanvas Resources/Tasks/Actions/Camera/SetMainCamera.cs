using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions{
	[Category("Camera")]
	public class SetMainCamera : ActionTask<Camera>
    {
        protected override void OnExecute(){
            if(Camera.main !=null)
            {
                Camera.main.tag = "Untagged";
            }
            agent.tag = "MainCamera";
            EndAction();
        }
    }
}