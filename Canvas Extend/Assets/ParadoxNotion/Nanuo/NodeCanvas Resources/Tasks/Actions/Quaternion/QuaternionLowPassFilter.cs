using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("Quaternion")]
    [Description("Use a low pass filter to reduce the influence of sudden changes in a quaternion Variable.")]
    public class QuaternionLowPassFilter : ActionTask
    {
        [Tooltip("quaternion Variable to filter. Should generally come from some constantly updated input")]
        public BBParameter<Quaternion> quaternion;
        [Tooltip("Determines how much influence new changes have. E.g., 0.1 keeps 10 percent of the unfiltered quaternion and 90 percent of the previously filtered value.")]
        public BBParameter<float> filteringFactor;
        Quaternion filteredQuaternion;
        protected override void OnExecute()
        {
            filteredQuaternion = new Quaternion(quaternion.value.x, quaternion.value.y, quaternion.value.z, quaternion.value.w);
            filteredQuaternion.x = (quaternion.value.x * filteringFactor.value) + (filteredQuaternion.x * (1.0f - filteringFactor.value));
            filteredQuaternion.y = (quaternion.value.y * filteringFactor.value) + (filteredQuaternion.y * (1.0f - filteringFactor.value));
            filteredQuaternion.z = (quaternion.value.z * filteringFactor.value) + (filteredQuaternion.z * (1.0f - filteringFactor.value));
            filteredQuaternion.w = (quaternion.value.w * filteringFactor.value) + (filteredQuaternion.w * (1.0f - filteringFactor.value));
            quaternion.value = new Quaternion(filteredQuaternion.x, filteredQuaternion.y, filteredQuaternion.z, filteredQuaternion.w);

            EndAction();
        }
    }
}