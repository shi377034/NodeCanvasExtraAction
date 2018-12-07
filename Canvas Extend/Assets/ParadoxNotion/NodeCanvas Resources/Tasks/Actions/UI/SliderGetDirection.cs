using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Get Direction")]
    [Category("UI/Slider")]
    public class SliderGetDirection : ActionTask<Slider>
    {
        [BlackboardOnly]
        public BBParameter<Slider.Direction> direction;
        protected override void OnExecute()
        {
            direction.value = agent.direction;
            EndAction();
        }
    }
}