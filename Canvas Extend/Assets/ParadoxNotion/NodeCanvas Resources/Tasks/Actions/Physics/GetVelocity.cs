using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions
{

    [Category("Physics")]
    public class GetVelocity : ActionTask<Rigidbody>
    {
        public Space space = Space.World;
        [BlackboardOnly]
        public BBParameter<Vector3> storeVelocity;
        [BlackboardOnly]
        public BBParameter<float> x;
        [BlackboardOnly]
        public BBParameter<float> y;
        [BlackboardOnly]
        public BBParameter<float> z;
        protected override void OnExecute()
        {
            var velocity = agent.velocity;
            if (space == Space.Self)
            {
                velocity = agent.transform.InverseTransformDirection(velocity);
            }
            storeVelocity.value = velocity;
            x.value = velocity.x;
            y.value = velocity.y;
            z.value = velocity.z;
            EndAction();
        }
    }
}