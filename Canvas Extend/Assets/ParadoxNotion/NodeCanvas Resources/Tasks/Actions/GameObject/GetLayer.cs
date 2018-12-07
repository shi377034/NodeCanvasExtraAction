using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions{

	[Category("GameObject")]
	public class GetLayer : ActionTask<GameObject>{
        [BlackboardOnly]
        public BBParameter<LayerMask> storeResult;

        protected override void OnExecute(){
            storeResult.value = agent.layer;
            EndAction();
		}
	}
}