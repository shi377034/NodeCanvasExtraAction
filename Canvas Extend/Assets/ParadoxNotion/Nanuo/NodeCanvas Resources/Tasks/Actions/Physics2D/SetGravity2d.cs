using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{

	[Category("Physics2D")]
	public class SetGravity2d : ActionTask
    {
        [Tooltip("Gravity as Vector2.")]
        public BBParameter<Vector2> vector;

        protected override void OnExecute(){
            Vector2 gravity = vector.value;
            Physics2D.gravity = gravity;
            EndAction();
		}
	}
}