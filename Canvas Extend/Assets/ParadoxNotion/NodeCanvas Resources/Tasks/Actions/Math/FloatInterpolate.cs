using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions{
    [Category("Math")]
    public class FloatInterpolate : ActionTask{
        public InterpolationType mode;
        public BBParameter<float> from;
        public BBParameter<float> to;
        public BBParameter<float> time;
        public BBParameter<float> storeResult;
        public BBParameter<bool> realTime;
        private float startTime;
        private float currentTime;
        protected override void OnExecute(){
            startTime = Time.realtimeSinceStartup;
            currentTime = 0f;
            storeResult.value = from.value;
        }
        protected override void OnUpdate()
        {
            // update time

            if (realTime.value)
            {
                currentTime = Time.realtimeSinceStartup - startTime;
            }
            else
            {
                currentTime += Time.deltaTime;
            }

            var lerpTime = currentTime / time.value;

            switch (mode)
            {

                case InterpolationType.Linear:

                    storeResult.value = Mathf.Lerp(from.value, to.value, lerpTime);

                    break;

                case InterpolationType.EaseInOut:

                    storeResult.value = Mathf.SmoothStep(from.value, to.value, lerpTime);

                    break;
            }

            if (lerpTime > 1)
            {
                EndAction();
            }
        }
    }
}