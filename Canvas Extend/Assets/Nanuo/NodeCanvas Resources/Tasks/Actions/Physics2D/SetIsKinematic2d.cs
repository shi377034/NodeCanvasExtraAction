using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{

	[Category("Physics2D")]
	public class SetIsKinematic2d : ActionTask<Rigidbody2D>
    {
        public BBParameter<bool> isKinematic;
        protected override void OnExecute(){
            agent.isKinematic = isKinematic.value;
            EndAction();
		}
	}
}