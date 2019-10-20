using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions
{
    [Category("Physics")]
    public class WakeAllRigidBodies : ActionTask
    {
        private Rigidbody[] bodies;
        protected override void OnExecute()
        {
            bodies = Object.FindObjectsOfType(typeof(Rigidbody)) as Rigidbody[];
            if (bodies != null)
            {
                foreach (var body in bodies)
                {
                    body.WakeUp();
                }
            }

            EndAction();
        }
    }
}