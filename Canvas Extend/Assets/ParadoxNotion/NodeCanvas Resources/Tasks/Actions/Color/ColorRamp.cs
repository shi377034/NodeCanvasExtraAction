using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;
namespace NodeCanvas.Tasks.Actions{
	[Category("Color")]
	public class ColorRamp : ActionTask
    {
        public BBParameter<List<Color>> colors;
        public BBParameter<float> sampleAt;
        [BlackboardOnly]
        public BBParameter<Color> storeColor;
        protected override void OnExecute(){
            if(colors.value.Count<2)
            {
                if(colors.value.Count == 1)
                {
                    storeColor.value = colors.value[0];
                }
                EndAction();
                return;
            }
            Color lerpColor;
            var lerpAmount = Mathf.Clamp(sampleAt.value, 0, colors.value.Count - 1);

            if (lerpAmount == 0)
            {
                lerpColor = colors.value[0];
            }
            else if (lerpAmount == colors.value.Count)
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

            EndAction();
        }
    }
}