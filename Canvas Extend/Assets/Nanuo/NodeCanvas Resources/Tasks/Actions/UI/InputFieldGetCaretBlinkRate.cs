using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Get CaretBlinkRate")]
    [Category("UI/InputField")]
    public class InputFieldGetCaretBlinkRate : ActionTask<InputField>
    {
        [BlackboardOnly]
        public BBParameter<float> caretBlinkRate;
        protected override void OnExecute()
        {
            caretBlinkRate.value = agent.caretBlinkRate;
            EndAction();
        }
    }
}