using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions{

	[Category("GameObject")]
	public class GetRoot : ActionTask<Transform>{
        [BlackboardOnly]
        public BBParameter<GameObject> storeResult;

        protected override void OnExecute(){
            storeResult.value = agent.root.gameObject;
            EndAction();
		}
	}
}