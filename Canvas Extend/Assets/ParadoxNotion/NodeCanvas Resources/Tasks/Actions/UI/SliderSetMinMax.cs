using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Set MinMax")]
    [Category("UI/Slider")]
    public class SliderSetMinMax : ActionTask<Slider>
    {
        public BBParameter<float> minValue;
        public BBParameter<float> maxValue;
        protected override void OnExecute()
        {
            agent.minValue = minValue.value;
            agent.maxValue = maxValue.value;
            EndAction();
        }
    }
}