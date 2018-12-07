using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Set Direction")]
    [Category("UI/Slider")]
    public class SliderSetDirection : ActionTask<Slider>
    {
        public BBParameter<Slider.Direction> direction;
        protected override void OnExecute()
        {
            agent.direction = direction.value;
            EndAction();
        }
    }
}