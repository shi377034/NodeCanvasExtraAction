using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("Quaternion")]
    public class QuaternionRotateTowards : ActionTask
    {
        public BBParameter<Quaternion> fromQuaternion;
        public BBParameter<Quaternion> toQuaternion;
        public BBParameter<float> maxDegreesDelta = 10f;
        [BlackboardOnly]
        public BBParameter<Quaternion> result;
        protected override void OnExecute()
        {
            result.value = Quaternion.RotateTowards(fromQuaternion.value, toQuaternion.value, maxDegreesDelta.value);
            EndAction();
        }
    }
}