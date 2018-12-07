using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;
namespace NodeCanvas.Tasks.Actions{
	[Category("Color")]
	public class ColorInterpolate : ActionTask
    {
        public BBParameter<List<Color>> colors;
        public BBParameter<float> time;
        [BlackboardOnly]
        public BBParameter<Color> storeColor;
        [Tooltip("Ignore TimeScale")]
        public BBParameter<float> realTime;

        private float startTime;
        private float currentTime;
        protected override string OnInit()
        {
            if (colors.value.Count < 2)
            {
                if (colors.value.Count == 1)
                {
                    storeColor.value = colors.value[0];
                }
                EndAction();
            }
            else
            {
                storeColor.value = colors.value[0];
            }
            return null;
        }
        protected override void OnUpdate()
        {
            if (elapsedTime > time.value)
            {
                storeColor.value = colors.value[colors.value.Count - 1];
                EndAction();
                return;
            }
            // lerp

            Color lerpColor;
            var lerpAmount = (colors.value.Count - 1) * elapsedTime / time.value;

            if (lerpAmount.Equals(0))
            {
                lerpColor = colors.value[0];
            }

            else if (lerpAmount.Equals(colors.value.Count - 1))
            {
                lerpColor = colors.value[colors.value.Count - 1];
            }

            else
            {
                var color1 = colors.value[Mathf.FloorToInt(lerpAmount)];
                var color2 = colors.value[Mathf.CeilToInt(lerpAmount)];
                lerpAmount -= Mathf.Floor(lerpAmount);

                lerpColor = Color.Lerp(color1, color2, lerpAmount);
            }

            storeColor.value = lerpColor;
        }
    }
}