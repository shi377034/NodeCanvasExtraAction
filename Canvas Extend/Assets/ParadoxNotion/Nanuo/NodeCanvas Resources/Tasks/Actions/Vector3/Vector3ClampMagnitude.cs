using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("ClampMagnitude")]
    [Category("Vector3")]
    public class Vector3ClampMagnitude : ActionTask
    {
        public BBParameter<Vector3> vector;
        public BBParameter<float> maxLength;
        [BlackboardOnly]
        public BBParameter<Vector3> storeVector;
        protected override void OnExecute()
        {
            storeVector.value = Vector3.ClampMagnitude(vector.value, maxLength.value);
            EndAction();
        }
    }
}