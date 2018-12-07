using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("MoveTowards")]
    [Category("Vector2")]
    public class Vector2MoveTowards : ActionTask
    {
        public BBParameter<Vector2> source;
        public BBParameter<Vector2> target;
        public BBParameter<float> maxSpeed = 10f;
        public BBParameter<float> finishDistance = 1f;
        public BBParameter<string> finishEvent;
        protected override void OnExecute()
        {
           
        }
        protected override void OnUpdate()
        {
            source.value = Vector2.MoveTowards(source.value, target.value, maxSpeed.value * Time.deltaTime);
            var distance = (source.value - target.value).magnitude;
            if (distance < finishDistance.value)
            {
                this.SendEvent(finishEvent.value);
                EndAction();
            }
        }
    }
}