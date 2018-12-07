using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Get WholeNumbers")]
    [Category("UI/Slider")]
    public class SliderGetWholeNumbers : ActionTask<Slider>
    {
        [BlackboardOnly]
        public BBParameter<bool> wholeNumbers;
        protected override void OnExecute()
        {
            wholeNumbers.value = agent.wholeNumbers;
            EndAction();
        }
    }
}