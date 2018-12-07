using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{

	[Category("Physics2D")]
	public class AddTorque2d : ActionTask<Rigidbody2D>
    {
        public ForceMode2D forceMode = ForceMode2D.Force;
        public BBParameter<float> torque;
        protected override void OnExecute(){
            agent.AddTorque(torque.value, forceMode);
            EndAction();
		}
	}
}