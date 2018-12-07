using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions
{
    [Category("Time")]
    [Description("Delays a State from finishing by a random time. NOTE: Other actions continue, but FINISHED can't happen before Time.")]
    public class RandomWait : ActionTask
    {
        [Tooltip("Minimum amount of time to wait.")]
        public BBParameter<float> min;
        [Tooltip("Maximum amount of time to wait.")]
        public BBParameter<float> max = 1f;
        [Tooltip("Ignore time scale.")]
        public BBParameter<bool> realTime;
        public BBParameter<string> finishEvent;
        private float startTime;
        private float timer;
        private float time;
        protected override string info
        {
            get { return string.Format("Wait Random {0}~{1}[{2}] sec", min, max, time); }
        }
        protected override void OnExecute()
        {
            time = Random.Range(min.value, max.value);

            if (time <= 0)
            {
                this.SendEvent(finishEvent.value);
                EndAction();
                return;
            }

            startTime = Time.time;
            timer = 0f;
        }
        protected override void OnUpdate()
        {
            if (realTime.value)
            {
                timer = elapsedTime;
            }
            else
            {
                timer += Time.deltaTime;
            }
            if (timer >= time)
            {
                this.SendEvent(finishEvent.value);
                EndAction();
            }
        }
    }
}