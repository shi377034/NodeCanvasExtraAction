using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("Quaternion")]
    public class QuaternionEuler : ActionTask
    {
        public BBParameter<Vector3> eulerAngles;
        [BlackboardOnly]
        public BBParameter<Quaternion> result;
        protected override void OnExecute()
        {
            result.value = Quaternion.Euler(eulerAngles.value);
            EndAction();
        }
    }
}