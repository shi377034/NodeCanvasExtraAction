using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Category("Vector3")]
    public class GetVector3XYZ : ActionTask
    {
        public BBParameter<Vector3> vector;
        [BlackboardOnly]
        public BBParameter<float> storeX;
        [BlackboardOnly]
        public BBParameter<float> storeY;
        [BlackboardOnly]
        public BBParameter<float> storeZ;
        protected override void OnExecute()
        {
            storeX.value = vector.value.x;
            storeY.value = vector.value.y;
            storeZ.value = vector.value.z;
            EndAction();
        }
    }
}