using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{

	[Category("Physics")]
	public class AddForce : ActionTask<Rigidbody>
    {
        [ShowIf("space", (int)Space.World)]
        public BBParameter<Vector3> atPosition;
        public BBParameter<Vector3> vector;
        public Space space= Space.World;
        public ForceMode forceMode = ForceMode.Force;
        protected override void OnExecute(){
            if (space == Space.World)
            {
                agent.AddForceAtPosition(vector.value, atPosition.value, forceMode);
            }
            else
            {
                agent.AddRelativeForce(vector.value, forceMode);
            }
            EndAction();
		}
	}
}