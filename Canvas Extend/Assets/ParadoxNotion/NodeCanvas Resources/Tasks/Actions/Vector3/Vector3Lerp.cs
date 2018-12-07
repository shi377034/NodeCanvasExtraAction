using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Lerp")]
    [Category("Vector3")]
    public class Vector3Lerp : ActionTask
    {
        public BBParameter<Vector3> fromVector;
        public BBParameter<Vector3> toVector;
        public BBParameter<float> amount;
        [BlackboardOnly]
        public BBParameter<Vector3> storeResult;
        protected override void OnExecute()
        {
            storeResult.value = Vector3.Lerp(fromVector.value, toVector.value, amount.value);
            EndAction();
        }
    }
}