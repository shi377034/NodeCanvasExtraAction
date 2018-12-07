using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions
{
    [Category("Rigidbody2D")]
    public class WakeUp2d : ActionTask<Rigidbody2D>
    {
        protected override void OnExecute()
        {
            agent.WakeUp();
            EndAction();
        }
    }
}