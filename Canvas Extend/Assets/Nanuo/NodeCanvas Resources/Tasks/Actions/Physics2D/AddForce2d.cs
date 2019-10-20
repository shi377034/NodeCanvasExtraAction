using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{

	[Category("Physics2D")]
	public class AddForce2d : ActionTask<Rigidbody2D>
    {
        public ForceMode2D forceMode = ForceMode2D.Force;
        public BBParameter<bool> AtPosition;
        [ShowIf("AtPosition",1)]
        public BBParameter<Vector2> position;
        public BBParameter<Vector2> vector;
        protected override void OnExecute(){
            var force = vector.value;
            // apply force	

            if (AtPosition.value)
            {
                agent.AddForceAtPosition(force, position.value, forceMode);
            }
            else
            {
                agent.AddForce(force, forceMode);
            }
            EndAction();
		}
	}
}