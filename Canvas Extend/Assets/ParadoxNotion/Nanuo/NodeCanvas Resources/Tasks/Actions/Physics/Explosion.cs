using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{

	[Category("Physics")]
	public class Explosion : ActionTask<Rigidbody>
    {
        public BBParameter<Vector3> center;
        public BBParameter<float> force;
        public BBParameter<float> radius;
        public BBParameter<float> upwardsModifier;
        public ForceMode forceMode = ForceMode.Force;
        public BBParameter<LayerMask> layerMask;
        public BBParameter<bool> invertMask;
        protected override void OnExecute(){
            var colliders = Physics.OverlapSphere(center.value, radius.value);
            foreach (var hit in colliders)
            {
                var rigidBody = hit.gameObject.GetComponent<Rigidbody>();
                if (rigidBody != null && ShouldApplyForce(hit.gameObject))
                {
                    rigidBody.AddExplosionForce(force.value, center.value, radius.value, upwardsModifier.value, forceMode);
                }
            }
            EndAction();
		}
        bool ShouldApplyForce(GameObject go)
        {
            var mask = layerMask.value;
            if(invertMask.value)
            {
                mask = ~mask;
            }
            return ((1 << go.layer) & mask) > 0;
        }
    }
}