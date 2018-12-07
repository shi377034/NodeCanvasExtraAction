using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions{

	[Category("GameObject")]
	public class GetChildIndex : ActionTask<Transform>{
        public BBParameter<int> index;
        [BlackboardOnly]
        public BBParameter<GameObject> store;

        protected override void OnExecute(){
            if(index.value < agent.childCount)
            {
                store.value = agent.GetChild(index.value).gameObject;
            }    
            EndAction();
		}
	}
}