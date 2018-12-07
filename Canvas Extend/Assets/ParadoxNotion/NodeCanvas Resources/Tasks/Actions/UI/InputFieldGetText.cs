using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Get Text")]
    [Category("UI/InputField")]
    public class InputFieldGetText : ActionTask<InputField>
    {
        [BlackboardOnly]
        public BBParameter<string> text;
        protected override void OnExecute()
        {
            text.value = agent.text;
            EndAction();
        }
    }
}