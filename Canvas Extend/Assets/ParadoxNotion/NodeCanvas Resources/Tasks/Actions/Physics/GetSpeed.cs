using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{

	[Category("Physics")]
	public class GetSpeed : ActionTask<Rigidbody>
    {
        [BlackboardOnly]
        public BBParameter<float> storeResult;
        protected override void OnExecute(){
            storeResult.value = agent.velocity.magnitude;
            EndAction();
		}
    }
}