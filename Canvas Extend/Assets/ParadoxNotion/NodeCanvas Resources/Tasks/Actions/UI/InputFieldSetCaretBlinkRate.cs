using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Set CaretBlinkRate")]
    [Category("UI/InputField")]
    public class InputFieldSetCaretBlinkRate : ActionTask<InputField>
    {
        public BBParameter<float> caretBlinkRate;
        protected override void OnExecute()
        {
            agent.caretBlinkRate = caretBlinkRate.value;
            EndAction();
        }
    }
}