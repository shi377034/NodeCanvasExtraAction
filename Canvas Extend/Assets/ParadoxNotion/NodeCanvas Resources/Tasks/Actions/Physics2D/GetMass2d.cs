using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{

	[Category("Physics2D")]
	public class GetMass2d : ActionTask<Rigidbody2D>
    {
        [BlackboardOnly]
        public BBParameter<float> storeResult;
        protected override void OnExecute(){
            storeResult.value = agent.mass;
            EndAction();
		}
	}
}