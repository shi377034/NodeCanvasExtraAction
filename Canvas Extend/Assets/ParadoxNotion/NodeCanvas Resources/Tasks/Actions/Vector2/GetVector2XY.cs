using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Category("Vector2")]
    public class GetVector2XY : ActionTask
    {
        public BBParameter<Vector2> vector;
        [BlackboardOnly]
        public BBParameter<float> storeX;
        [BlackboardOnly]
        public BBParameter<float> storeY;
        protected override void OnExecute()
        {
            storeX.value = vector.value.x;
            storeY.value = vector.value.y;
            EndAction();
        }
    }
}