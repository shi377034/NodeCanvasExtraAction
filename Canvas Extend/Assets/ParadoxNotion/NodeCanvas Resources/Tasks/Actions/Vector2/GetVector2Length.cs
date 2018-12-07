using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Category("Vector2")]
    public class GetVector2Length : ActionTask
    {
        public BBParameter<Vector2> vector;
        [BlackboardOnly]
        public BBParameter<float> storeLength;
        protected override void OnExecute()
        {
            storeLength.value = vector.value.magnitude;
            EndAction();
        }
    }
}