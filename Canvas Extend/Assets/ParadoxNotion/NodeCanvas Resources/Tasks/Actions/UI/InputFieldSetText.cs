using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Set Text")]
    [Category("UI/InputField")]
    public class InputFieldSetText : ActionTask<InputField>
    {
        public BBParameter<string> text;
        protected override void OnExecute()
        {
            agent.text = text.value;
            EndAction();
        }
    }
}