using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Category("Transform")]
    public class InverseTransformPoint : ActionTask<Transform>
    {
        public BBParameter<Vector3> worldPosition;
        [BlackboardOnly]
        public BBParameter<Vector3> storeResult;
        protected override void OnExecute()
        {
            storeResult.value = agent.InverseTransformPoint(worldPosition.value);
            EndAction();
        }
    }
}