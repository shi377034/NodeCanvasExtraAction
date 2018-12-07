using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions
{
    [Category("Rigidbody2D")]
    public class WakeAllRigidBodies2d : ActionTask
    {
        private Rigidbody2D[] bodies;
        protected override void OnExecute()
        {
            bodies = Object.FindObjectsOfType(typeof(Rigidbody2D)) as Rigidbody2D[];
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