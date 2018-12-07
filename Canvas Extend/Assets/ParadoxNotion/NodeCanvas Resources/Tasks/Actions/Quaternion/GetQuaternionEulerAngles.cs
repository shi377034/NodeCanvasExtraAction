using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("Quaternion")]
    public class GetQuaternionEulerAngles : ActionTask
    {
        public BBParameter<Quaternion> quaternion;
        [BlackboardOnly]
        public BBParameter<Vector3> eulerAngles;
        protected override void OnExecute()
        {
            eulerAngles.value = quaternion.value.eulerAngles;
            EndAction();
        }
    }
}