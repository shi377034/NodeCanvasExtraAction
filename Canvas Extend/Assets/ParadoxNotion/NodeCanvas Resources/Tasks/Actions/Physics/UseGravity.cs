using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions
{
    [Category("Physics")]
    public class UseGravity : ActionTask<Rigidbody>
    {
        public BBParameter<bool> useGravity;
        protected override void OnExecute()
        {
            agent.useGravity = useGravity.value;
            EndAction();
        }
    }
}