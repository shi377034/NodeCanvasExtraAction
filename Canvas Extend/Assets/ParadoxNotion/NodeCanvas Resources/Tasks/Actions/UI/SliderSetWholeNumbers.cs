using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Set WholeNumbers")]
    [Category("UI/Slider")]
    public class SliderSetWholeNumbers : ActionTask<Slider>
    {
        public BBParameter<bool> wholeNumbers;
        protected override void OnExecute()
        {
            agent.wholeNumbers = wholeNumbers.value;
            EndAction();
        }
    }
}