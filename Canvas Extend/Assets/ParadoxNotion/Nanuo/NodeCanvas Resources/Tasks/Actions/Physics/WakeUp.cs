using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions
{
    [Category("Physics")]
    public class WakeUp : ActionTask<Rigidbody>
    {
        protected override void OnExecute()
        {
            agent.WakeUp();
            EndAction();
        }
    }
}