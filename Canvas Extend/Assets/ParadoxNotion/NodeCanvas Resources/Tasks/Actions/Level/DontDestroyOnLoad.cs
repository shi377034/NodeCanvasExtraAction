using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions{

	[Category("Level")]
	public class DontDestroyOnLoad : ActionTask<Transform>{
        protected override void OnExecute(){
            Object.DontDestroyOnLoad(agent.root.gameObject);
            EndAction();
		}
	}
}