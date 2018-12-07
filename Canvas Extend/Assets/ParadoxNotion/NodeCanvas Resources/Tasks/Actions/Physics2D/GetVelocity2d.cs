using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{

	[Category("Physics2D")]
	public class GetVelocity2d : ActionTask<Rigidbody2D>
    {
        public Space space = Space.World;
        [BlackboardOnly]
        public BBParameter<Vector2> vector;
        [BlackboardOnly]
        public BBParameter<float> x;
        [BlackboardOnly]
        public BBParameter<float> y;
        protected override void OnExecute(){
            var velocity = agent.velocity;

            if (space == Space.Self)
            {
                velocity = agent.transform.InverseTransformDirection(velocity);
            }

            vector.value = velocity;
            x.value = velocity.x;
            y.value = velocity.y;
            EndAction();
		}
	}
}