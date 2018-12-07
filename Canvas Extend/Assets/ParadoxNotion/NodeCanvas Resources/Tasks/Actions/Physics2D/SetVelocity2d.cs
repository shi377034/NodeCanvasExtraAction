using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{

	[Category("Physics2D")]
	public class SetVelocity2d : ActionTask<Rigidbody2D>
    {
        public BBParameter<Vector2> vector;
        protected override void OnExecute(){
            agent.velocity = vector.value;
            EndAction();
		}
	}
}