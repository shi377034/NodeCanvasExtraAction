using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Set Size")]
    [Category("UI/Scrollbar")]
    public class ScrollbarSetSize : ActionTask<Scrollbar>
    {
        [SliderField(0,1f)]
        public BBParameter<float> value;
        protected override void OnExecute()
        {
            agent.size = value.value;
            EndAction();
        }
    }
}