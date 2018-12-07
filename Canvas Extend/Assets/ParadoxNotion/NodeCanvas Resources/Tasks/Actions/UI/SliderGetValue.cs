using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Get Value")]
    [Category("UI/Slider")]
    public class SliderGetValue : ActionTask<Slider>
    {
        [BlackboardOnly]
        public BBParameter<float> value;
        protected override void OnExecute()
        {
            value.value = agent.value;
            EndAction();
        }
    }
}