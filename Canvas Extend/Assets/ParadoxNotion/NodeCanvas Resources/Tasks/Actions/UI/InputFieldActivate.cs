using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("ActivateInputField")]
    [Category("UI/InputField")]
    public class InputFieldActivate : ActionTask<InputField>
    {
        protected override void OnExecute()
        {
            agent.ActivateInputField();
            EndAction();
        }
    }
}