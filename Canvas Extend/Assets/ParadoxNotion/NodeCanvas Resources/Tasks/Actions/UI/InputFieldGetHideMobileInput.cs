using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Get ShouldHideMobileInput")]
    [Category("UI/InputField")]
    public class InputFieldGetHideMobileInput : ActionTask<InputField>
    {
        [BlackboardOnly]
        public BBParameter<bool> hideMobileInput;
        protected override void OnExecute()
        {
            hideMobileInput.value = agent.shouldHideMobileInput;
            EndAction();
        }
    }
}