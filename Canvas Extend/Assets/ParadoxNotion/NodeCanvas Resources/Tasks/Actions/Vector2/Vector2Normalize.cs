using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Normalize")]
    [Category("Vector2")]
    public class Vector2Normalize : ActionTask
    {
        public BBParameter<Vector2> vector;
        [BlackboardOnly]
        public BBParameter<Vector2> storeResult;
        protected override void OnExecute()
        {
            storeResult.value = vector.value.normalized;
            EndAction();
        }
    }
}