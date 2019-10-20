using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("Quaternion")]
    public class QuaternionInverse : ActionTask
    {
        public BBParameter<Quaternion> rotation;
        [BlackboardOnly]
        public BBParameter<Quaternion> result;
        protected override void OnExecute()
        {
            result.value = Quaternion.Inverse(rotation.value);
            EndAction();
        }
    }
}