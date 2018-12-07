using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Set SelectionColor")]
    [Category("UI/InputField")]
    public class InputFieldSetSelectionColor : ActionTask<InputField>
    {
        public BBParameter<Color> selectionColor;
        protected override void OnExecute()
        {
            agent.selectionColor = selectionColor.value;
            EndAction();
        }
    }
}