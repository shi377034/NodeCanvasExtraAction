using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Category("Transform")]
    public class TransformPoint : ActionTask<Transform>
    {
        public BBParameter<Vector3> localPosition;
        [BlackboardOnly]
        public BBParameter<Vector3> storeResult;
        protected override void OnExecute()
        {
            storeResult.value = agent.TransformPoint(localPosition.value);
            EndAction();
        }
    }
}