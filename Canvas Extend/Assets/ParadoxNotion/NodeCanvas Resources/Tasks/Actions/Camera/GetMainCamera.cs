using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions{
	[Category("Camera")]
	public class GetMainCamera : ActionTask
    {
        [BlackboardOnly]
        public BBParameter<Camera> saveAs;
        protected override void OnExecute(){
            saveAs.value = Camera.main;
            EndAction();
        }
    }
}