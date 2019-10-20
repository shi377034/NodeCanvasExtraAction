using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Get NormalizedValue")]
    [Category("UI/Slider")]
    public class SliderGetNormalizedValue : ActionTask<Slider>
    {
        [BlackboardOnly]
        public BBParameter<float> normalizedValue;
        protected override void OnExecute()
        {
            normalizedValue.value = agent.normalizedValue;
            EndAction();
        }
    }
}