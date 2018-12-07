using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions{

	[Category("GameObject")]
	public class DetachChildren : ActionTask<Transform>{

		protected override void OnExecute(){
            agent.DetachChildren();
            EndAction();
		}
	}
}