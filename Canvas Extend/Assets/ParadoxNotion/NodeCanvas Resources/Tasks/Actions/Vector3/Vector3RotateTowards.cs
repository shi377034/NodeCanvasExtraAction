using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("RotateTowards")]
    [Category("Vector3")]
    public class Vector3RotateTowards : ActionTask
    {
        public BBParameter<Vector3> currentDirection;
        public BBParameter<Vector3> targetDirection;
        public BBParameter<float> rotateSpeed = 360f;
        public BBParameter<float> maxMagnitude = 1f;
        protected override void OnExecute()
        {
            currentDirection.value = Vector3.RotateTowards(currentDirection.value, targetDirection.value, rotateSpeed.value * Mathf.Deg2Rad * Time.deltaTime, maxMagnitude.value);
            EndAction();
        }
    }
}