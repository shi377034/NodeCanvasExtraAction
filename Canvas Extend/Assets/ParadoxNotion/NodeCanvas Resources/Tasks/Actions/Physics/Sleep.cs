using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions
{
    [Category("Physics")]
    public class Sleep : ActionTask<Rigidbody>
    {
        protected override void OnExecute()
        {
            agent.Sleep();
            EndAction();
        }
    }
}