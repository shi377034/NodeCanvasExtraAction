using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions{

	[Category("GameObject")]
	public class GetParent : ActionTask<GameObject>{
        [BlackboardOnly]
        public BBParameter<GameObject> storeResult;

        protected override void OnExecute(){
            storeResult.value = agent.transform.parent.gameObject;
            EndAction();
		}
	}
}