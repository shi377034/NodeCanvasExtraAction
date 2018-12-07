using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions{

	[Category("GameObject")]
	public class GetRandomChild : ActionTask<Transform>{
        [BlackboardOnly]
        public BBParameter<GameObject> storeResult;

        protected override void OnExecute(){
            int childCount = agent.childCount;
            if (childCount > 0)
            {
                storeResult.value = agent.GetChild(Random.Range(0, childCount)).gameObject;
            }        
            EndAction();
		}
	}
}