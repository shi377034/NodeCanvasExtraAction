using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("Quaternion")]
    public class GetQuaternionFromRotation : ActionTask
    {
        [Name("from")]
        public BBParameter<Vector3> fromDirection;
        [Name("to")]
        public BBParameter<Vector3> toDirection;
        [BlackboardOnly]
        public BBParameter<Quaternion> result;
        protected override void OnExecute()
        {
            result.value = Quaternion.FromToRotation(fromDirection.value, toDirection.value);
            EndAction();
        }
    }
}