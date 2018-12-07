using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Set Value")]
    [Category("UI/Scrollbar")]
    public class ScrollbarSetValue : ActionTask<Scrollbar>
    {
        public BBParameter<float> value;
        protected override void OnExecute()
        {
            agent.value = value.value;
            EndAction();
        }
    }
}