using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Get MinMax")]
    [Category("UI/Slider")]
    public class SliderGetMinMax : ActionTask<Slider>
    {
        [BlackboardOnly]
        public BBParameter<Vector2> vector;
        [BlackboardOnly]
        public BBParameter<float> minValue;
        [BlackboardOnly]
        public BBParameter<float> maxValue;
        protected override void OnExecute()
        {
            vector.value = new Vector2(agent.minValue,agent.maxValue);
            minValue.value = agent.minValue;
            maxValue.value = agent.maxValue;
            EndAction();
        }
    }
}