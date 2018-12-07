using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Category("Vector2")]
    public class ExtractVector2 : ActionTask
    {
        public BBParameter<Vector2> vector;
        [BlackboardOnly]
        public BBParameter<float> storeX;
        [BlackboardOnly]
        public BBParameter<float> storeY;
        [BlackboardOnly]
        public BBParameter<float> storeMagnitude;
        [BlackboardOnly]
        public BBParameter<float> storeSqrMagnitude;
        protected override void OnExecute()
        {
            storeX.value = vector.value.x;
            storeY.value = vector.value.y;
            storeMagnitude.value = vector.value.magnitude;
            storeSqrMagnitude.value = vector.value.sqrMagnitude;
            EndAction();
        }
    }
}