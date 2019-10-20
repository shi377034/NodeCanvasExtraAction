using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("Quaternion")]
    public class QuaternionAngleAxis : ActionTask
    {
        public BBParameter<float> angle;
        public BBParameter<Vector3> axis;
        [BlackboardOnly]
        public BBParameter<Quaternion> result;
        protected override void OnExecute()
        {
            result.value = Quaternion.AngleAxis(angle.value, axis.value);
            EndAction();
        }
    }
}