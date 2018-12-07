using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Get IsOn")]
    [Category("UI/Toggle")]
    public class ToggleGetIsOn : ActionTask<Toggle>
    {
        [BlackboardOnly]
        public BBParameter<bool> value;
        protected override void OnExecute()
        {
            value.value = agent.isOn;
            EndAction();
        }
    }
}