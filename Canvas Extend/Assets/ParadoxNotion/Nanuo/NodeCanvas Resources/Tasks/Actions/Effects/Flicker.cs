using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;
namespace NodeCanvas.Tasks.Actions{
	[Category("Effects")]
	public class Flicker : ActionTask<Renderer>
    {
        [SliderField(0,1f)]
        public BBParameter<float> frequency = 0.1f;
        [SliderField(0, 1f)]
        public BBParameter<float> amountOn = 0.5f;
        public BBParameter<bool> rendererOnly;
        public BBParameter<bool> finish;
        [Tooltip("Ignore TimeScale. Useful if the game is paused.")]
        public BBParameter<bool> realTime;
        private float startTime;
        private float timer;

        protected override void OnExecute()
        {
            startTime = Time.realtimeSinceStartup;
            timer = 0f;
        }
        protected override void OnUpdate()
        {
            // update time

            if (realTime.value)
            {
                timer = Time.realtimeSinceStartup - startTime;
            }
            else
            {
                timer += Time.deltaTime;
            }

            if (timer > frequency.value)
            {
                var on = Random.Range(0f, 1f) < amountOn.value;

                // do flicker

                if (rendererOnly.value)
                {
                    agent.enabled = on;
                }
                else
                {
#if UNITY_3_5 || UNITY_3_4
                    agent.gameObject.active = on;
#else				
                    agent.gameObject.SetActive(on);
#endif
                }
                timer = 0;
            }
            if (finish.value)
            {
                EndAction();
            }
        }
    }
}