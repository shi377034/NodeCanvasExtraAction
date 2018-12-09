using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions
{
    [Category("Physics")]
    public class SetVelocity : ActionTask<Rigidbody>
    {
        public BBParameter<Vector3> vector;
        public Space space = Space.Self;
        protected override void OnExecute()
        {
            Vector3 velocity;

            velocity = space == Space.World ?
                    agent.velocity :
                    agent.transform.InverseTransformDirection(agent.velocity);
            // apply
            agent.velocity = space == Space.World ? velocity : agent.transform.TransformDirection(velocity);
            EndAction();
        }
    }
}