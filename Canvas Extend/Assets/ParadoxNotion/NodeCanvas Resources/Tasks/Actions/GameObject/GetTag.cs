using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions{

	[Category("GameObject")]
	public class GetTag : ActionTask<GameObject>{
        [BlackboardOnly]
        public BBParameter<string> storeResult;

        protected override void OnExecute(){
            storeResult.value = agent.tag;
            EndAction();
		}
	}
}