using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{

	[Category("Physics")]
	public class AddTorque : ActionTask<Rigidbody>
    {
        public BBParameter<Vector3> vector;
        public Space space = Space.World;
        public ForceMode forceMode = ForceMode.Force;
        protected override void OnExecute(){
            if (space == Space.World)
            {
                agent.AddTorque(vector.value, forceMode);
            }
            else
            {
                agent.AddRelativeTorque(vector.value, forceMode);
            }
            EndAction();
		}
	}
}