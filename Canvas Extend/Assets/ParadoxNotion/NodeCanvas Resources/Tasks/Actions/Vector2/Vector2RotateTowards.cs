using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("RotateTowards")]
    [Category("Vector2")]
    public class Vector2RotateTowards : ActionTask
    {
        public BBParameter<Vector2> currentDirection;
        public BBParameter<Vector2> targetDirection;
        public BBParameter<float> rotateSpeed = 360f;
        private Vector3 current;
        private Vector3 target;
        protected override void OnExecute()
        {
            current = new Vector3(currentDirection.value.x, currentDirection.value.y, 0f);
            target = new Vector3(targetDirection.value.x, targetDirection.value.y, 0f);
            current.x = currentDirection.value.x;
            current.y = currentDirection.value.y;

            current = Vector3.RotateTowards(current, target,
                rotateSpeed.value * Mathf.Deg2Rad * Time.deltaTime, 1000);

            currentDirection.value = new Vector2(current.x, current.y);
            EndAction();
        }
    }
}