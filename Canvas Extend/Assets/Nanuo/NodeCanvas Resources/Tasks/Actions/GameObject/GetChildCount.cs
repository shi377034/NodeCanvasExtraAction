using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions{

	[Category("GameObject")]
	public class GetChildCount : ActionTask<Transform>{
        [BlackboardOnly]
        public BBParameter<int> storeResult;

        protected override void OnExecute(){
            storeResult.value = agent.childCount;
            EndAction();
		}
	}
}