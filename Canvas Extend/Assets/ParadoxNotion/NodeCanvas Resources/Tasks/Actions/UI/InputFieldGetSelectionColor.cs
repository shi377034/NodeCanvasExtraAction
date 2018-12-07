using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Get SelectionColor")]
    [Category("UI/InputField")]
    public class InputFieldGetSelectionColor : ActionTask<InputField>
    {
        [BlackboardOnly]
        public BBParameter<Color> selectionColor;
        protected override void OnExecute()
        {
            selectionColor.value = agent.selectionColor;
            EndAction();
        }
    }
}