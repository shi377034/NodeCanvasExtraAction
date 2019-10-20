using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions{

	[Category("Time")]
	public class RandomWait : ConditionTask{
        [Tooltip("Minimum amount of time to wait.")]
        public BBParameter<float> min;
        [Tooltip("Maximum amount of time to wait.")]
        public BBParameter<float> max = 1f;
        [Tooltip("Ignore time scale.")]
        public BBParameter<bool> realTime;
        private float startTime;
        private float timer;
        private float time;
        protected override void OnEnable()
        {
            startTime = Time.time;
            timer = 0;
        }
        protected override bool OnCheck(){
            time = Random.Range(min.value, max.value);

            if (time <= 0)
            {
                return true;
            }
      
            if (realTime.value)
            {
                timer = Time.time - startTime;
            }
            else
            {
                timer += Time.deltaTime;
            }
            if (timer >= time)
            {
                startTime = Time.time;
                timer = 0f;
                return true;
            }
            return false;					
		}
	}
}