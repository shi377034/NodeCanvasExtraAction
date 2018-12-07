using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Interpolate")]
    [Category("Vector3")]
    public class Vector3Interpolate : ActionTask
    {
        public enum InterpolationType
        {
            Linear = 0,
            EaseInOut = 1
        }
        public InterpolationType mode;
        public BBParameter<Vector3> fromVector;
        public BBParameter<Vector3> toVector;
        public BBParameter<float> time;
        public BBParameter<bool> realTime;
        public BBParameter<string> finishEvent;
        [BlackboardOnly]
        public BBParameter<Vector3> storeVector;
        private float currentTime;
        protected override void OnExecute()
        {
            currentTime = 0f;
        }
        protected override void OnUpdate()
        {
            if (realTime.value)
            {
                currentTime = elapsedTime;
            }
            else
            {
                currentTime += Time.deltaTime;
            }
            float weight = currentTime / time.value;

            switch (mode)
            {
                case InterpolationType.Linear:
                    break;
                case InterpolationType.EaseInOut:
                    weight = Mathf.SmoothStep(0, 1, weight);
                    break;
            }

            storeVector.value = Vector2.Lerp(fromVector.value, toVector.value, weight);

            if (weight > 1)
            {
                this.SendEvent(finishEvent.value);
                EndAction();
            }
        }
    }
}