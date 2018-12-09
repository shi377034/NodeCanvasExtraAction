using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Category("Vector3")]
    public class GetVector3Length : ActionTask
    {
        public BBParameter<Vector3> vector;
        [BlackboardOnly]
        public BBParameter<float> storeLength;
        protected override void OnExecute()
        {
            storeLength.value = vector.value.magnitude;
            EndAction();
        }
    }
}