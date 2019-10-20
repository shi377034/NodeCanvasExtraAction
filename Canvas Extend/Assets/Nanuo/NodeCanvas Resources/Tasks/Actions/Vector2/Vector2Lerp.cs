using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Lerp")]
    [Category("Vector2")]
    public class Vector2Lerp : ActionTask
    {
        public BBParameter<Vector2> fromVector;
        public BBParameter<Vector2> toVector;
        public BBParameter<float> amount;
        [BlackboardOnly]
        public BBParameter<Vector2> storeResult;
        protected override void OnExecute()
        {
            storeResult.value = Vector2.Lerp(fromVector.value, toVector.value, amount.value);
            EndAction();
        }
    }
}