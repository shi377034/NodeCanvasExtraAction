using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;
namespace NodeCanvas.Tasks.Actions{
	[Category("Effects")]
	public class Blink : ActionTask<Renderer>
    {
        [SliderField(0,5f)]
        public BBParameter<float> timeOff = 0.5f;
        [SliderField(0,5f)]
        public BBParameter<float> timeOn = 0.5f;
        public BBParameter<bool> startOn;
        public BBParameter<bool> rendererOnly = true;
        public BBParameter<bool> finish;
        [Tooltip("Ignore TimeScale. Useful if the game is paused.")]
        public BBParameter<bool> realTime;
        private float startTime;
        private float timer;
        private bool blinkOn;
        protected override void OnExecute()
        {
            startTime = Time.realtimeSinceStartup;
            timer = 0f;
            UpdateBlinkState(startOn.value);
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

            if (blinkOn && timer > timeOn.value)
            {
                UpdateBlinkState(false);
            }

            if (blinkOn == false && timer > timeOff.value)
            {
                UpdateBlinkState(true);
            }
            if(finish.value)
            {
                EndAction();
            }
        }
        void UpdateBlinkState(bool state)
        {
            if (rendererOnly.value)
            {
                agent.enabled = state;
            }
            else
            {
#if UNITY_3_5 || UNITY_3_4
                agent.gameObject.active = state;
#else          
                agent.gameObject.SetActive(state);
#endif
            }
            blinkOn = state;
        }
    }
}