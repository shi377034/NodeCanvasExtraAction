using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions{

	[Category("Input")]
	public class ResetInputAxes : ActionTask {
		protected override void OnExecute(){
            Input.ResetInputAxes();
            EndAction();
        }
	}
}