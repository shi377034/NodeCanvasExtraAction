using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Set NormalizedValue")]
    [Category("UI/Slider")]
    public class SliderSetNormalizedValue : ActionTask<Slider>
    {
        public BBParameter<float> normalizedValue;
        protected override void OnExecute()
        {
            agent.normalizedValue = normalizedValue.value;
            EndAction();
        }
    }
}