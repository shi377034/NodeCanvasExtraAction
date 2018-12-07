using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Set ShouldHideMobileInput")]
    [Category("UI/InputField")]
    public class InputFieldSetHideMobileInput : ActionTask<InputField>
    {
        public BBParameter<bool> hideMobileInput;
        protected override void OnExecute()
        {
            agent.shouldHideMobileInput = hideMobileInput.value;
            EndAction();
        }
    }
}