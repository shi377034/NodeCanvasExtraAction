using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("DeactivateInputField")]
    [Category("UI/InputField")]
    public class InputFieldDeactivate : ActionTask<InputField>
    {
        protected override void OnExecute()
        {
            agent.DeactivateInputField();
            EndAction();
        }
    }
}