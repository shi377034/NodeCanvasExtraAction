using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{

	[Category("Physics2D")]
	public class Sleep2d : ActionTask<Rigidbody2D>
    {
        protected override void OnExecute(){
            agent.Sleep();
            EndAction();
		}
	}
}