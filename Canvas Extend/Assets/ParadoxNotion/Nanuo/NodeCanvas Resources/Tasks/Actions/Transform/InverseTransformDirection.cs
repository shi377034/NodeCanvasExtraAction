using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Category("Transform")]
    public class InverseTransformDirection : ActionTask<Transform>
    {
        public BBParameter<Vector3> worldDirection;
        [BlackboardOnly]
        public BBParameter<Vector3> storeResult;
        protected override void OnExecute()
        {
            storeResult.value = agent.InverseTransformDirection(worldDirection.value);
            EndAction();
        }
    }
}