using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions
{
    [Category("Physics")]
    public class SetJointConnectedBody : ActionTask<Joint>
    {
        public BBParameter<Rigidbody> rigidBody;
        protected override void OnExecute()
        {
            agent.connectedBody = rigidBody.value;
            EndAction();
        }
    }
}