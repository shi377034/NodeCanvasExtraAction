using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("ClampMagnitude")]
    [Category("Vector2")]
    public class Vector2ClampMagnitude : ActionTask
    {
        public BBParameter<Vector2> vector;
        public BBParameter<float> maxLength;
        [BlackboardOnly]
        public BBParameter<Vector2> storeVector;
        protected override void OnExecute()
        {
            storeVector.value = Vector2.ClampMagnitude(vector.value, maxLength.value);
            EndAction();
        }
    }
}