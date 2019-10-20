using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions{

	[Category("GameObject")]
	public class SetParent : ActionTask<Transform>{
        public BBParameter<Transform> parent;
        public BBParameter<bool> resetLocalPosition;
        public BBParameter<bool> resetLocalRotation;
        protected override void OnExecute(){
            agent.SetParent(parent.value);
            if(resetLocalPosition.value)
            {
                agent.localPosition = Vector3.zero;
            }
            if(resetLocalRotation.value)
            {
                agent.localRotation = Quaternion.identity;
            }
            EndAction();
		}
	}
}