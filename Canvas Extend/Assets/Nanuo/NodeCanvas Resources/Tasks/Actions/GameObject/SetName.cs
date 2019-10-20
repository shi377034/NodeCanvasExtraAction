using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions{

	[Category("GameObject")]
	public class SetName : ActionTask<GameObject>{
        public BBParameter<string> Name;
        protected override void OnExecute(){
            agent.name = Name.value;
            EndAction();
		}
	}
}