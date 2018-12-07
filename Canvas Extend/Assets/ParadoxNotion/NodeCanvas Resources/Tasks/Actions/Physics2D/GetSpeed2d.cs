using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{

	[Category("Physics2D")]
	public class GetSpeed2d : ActionTask<Rigidbody2D>
    {
        [BlackboardOnly]
        public BBParameter<float> storeResult;
        protected override void OnExecute(){
            storeResult.value = agent.velocity.magnitude;
            EndAction();
		}
	}
}