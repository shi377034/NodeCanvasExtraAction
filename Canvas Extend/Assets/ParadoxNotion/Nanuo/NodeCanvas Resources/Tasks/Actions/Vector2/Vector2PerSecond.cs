using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("PerSecond")]
    [Category("Vector2")]
    public class Vector2PerSecond : ActionTask
    {
        public BBParameter<Vector2> vector;
        [BlackboardOnly]
        public BBParameter<Vector2> storeResult;
        protected override void OnExecute()
        {
            storeResult.value = vector.value * Time.deltaTime;
            EndAction();
        }
    }
}