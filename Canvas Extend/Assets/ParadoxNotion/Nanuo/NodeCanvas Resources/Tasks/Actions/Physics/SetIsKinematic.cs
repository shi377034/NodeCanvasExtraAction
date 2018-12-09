using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions
{
    [Category("Physics")]
    public class SetIsKinematic : ActionTask<Rigidbody>
    {
        public BBParameter<bool> isKinematic;
        protected override void OnExecute()
        {
            agent.isKinematic = isKinematic.value;
            EndAction();
        }
    }
}