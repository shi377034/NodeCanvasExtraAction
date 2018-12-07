using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("LowPassFilter")]
    [Category("Vector3")]
    [Description("Use a low pass filter to reduce the influence of sudden changes in a Vector2 Variable.")]
    public class Vector3LowPassFilter : ActionTask
    {
        public BBParameter<Vector3> vector;
        public BBParameter<float> filteringFactor = 0.1f;
        Vector3 filteredVector;
        protected override void OnExecute()
        {
            filteredVector = new Vector3(vector.value.x, vector.value.y);
            filteredVector.x = (vector.value.x * filteringFactor.value) + (filteredVector.x * (1.0f - filteringFactor.value));
            filteredVector.y = (vector.value.y * filteringFactor.value) + (filteredVector.y * (1.0f - filteringFactor.value));
            filteredVector.z = (vector.value.z * filteringFactor.value) + (filteredVector.z * (1.0f - filteringFactor.value));
            vector.value = new Vector3(filteredVector.x, filteredVector.y, filteredVector.z);
            EndAction();
        }
    }
}