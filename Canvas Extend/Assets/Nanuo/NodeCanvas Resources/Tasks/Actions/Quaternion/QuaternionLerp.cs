using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("Quaternion")]
    public class QuaternionLerp : ActionTask
    {
        public BBParameter<Quaternion> fromQuaternion;
        public BBParameter<Quaternion> toQuaternion;
        [SliderField(0f,1f)]
        public BBParameter<float> amount;
        [BlackboardOnly]
        public BBParameter<Quaternion> result;
        protected override void OnExecute()
        {
            result.value = Quaternion.Lerp(fromQuaternion.value, toQuaternion.value, amount.value);
            EndAction();
        }
    }
}