using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{

	[Category("Physics2D")]
	public class SetGravity2dScale : ActionTask<Rigidbody2D>
    {
        public BBParameter<float> gravityScale = 1f;
        protected override void OnExecute(){
            agent.gravityScale = gravityScale.value;
            EndAction();
		}
	}
}