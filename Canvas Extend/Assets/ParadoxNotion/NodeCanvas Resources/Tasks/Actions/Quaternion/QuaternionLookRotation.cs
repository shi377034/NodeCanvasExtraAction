using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("Quaternion")]
    public class QuaternionLookRotation : ActionTask
    {
        public BBParameter<Vector3> direction;
        public BBParameter<Vector3> upVector;
        [BlackboardOnly]
        public BBParameter<Quaternion> result;
        protected override void OnExecute()
        {
            result.value = Quaternion.LookRotation(direction.value, upVector.value);
            EndAction();
        }
    }
}