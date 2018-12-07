using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{

	[Category("Physics")]
	public class AddExplosionForce : ActionTask<Rigidbody>
    {
        public BBParameter<Vector3> center;
        public BBParameter<float> force;
        public BBParameter<float> radius;
        public BBParameter<float> upwardsModifier;
        public ForceMode forceMode = ForceMode.Force;
        protected override void OnExecute(){
            agent.AddExplosionForce(force.value, center.value, radius.value, upwardsModifier.value, forceMode);
            EndAction();
		}
	}
}