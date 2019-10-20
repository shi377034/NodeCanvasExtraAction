using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Category("Transform")]
    public class TransformDirection : ActionTask<Transform>
    {
        public BBParameter<Vector3> localDirection;
        [BlackboardOnly]
        public BBParameter<Vector3> storeResult;
        protected override void OnExecute()
        {
            storeResult.value = agent.TransformDirection(localDirection.value);
            EndAction();
        }
    }
}