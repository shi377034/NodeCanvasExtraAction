using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{

	[Category("Physics2D")]
	public class AddRelativeForce2d : ActionTask<Rigidbody2D>
    {
        public ForceMode2D forceMode = ForceMode2D.Force;
        public BBParameter<Vector2> vector;
        protected override void OnExecute(){
            agent.AddRelativeForce(vector.value, forceMode);
            EndAction();
		}
	}
}