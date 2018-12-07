using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Set IsOn")]
    [Category("UI/Toggle")]
    public class ToggleSetIsOn : ActionTask<Toggle>
    {
        public BBParameter<bool> isOn;
        protected override void OnExecute()
        {
            agent.isOn = isOn.value;
            EndAction();
        }
    }
}