using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Normalize")]
    [Category("Vector3")]
    public class Vector3Normalize : ActionTask
    {
        public BBParameter<Vector3> vector;
        [BlackboardOnly]
        public BBParameter<Vector3> storeResult;
        protected override void OnExecute()
        {
            storeResult.value = vector.value.normalized;
            EndAction();
        }
    }
}