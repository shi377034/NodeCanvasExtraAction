using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("MoveTextStart")]
    [Category("UI/InputField")]
    public class InputFieldMoveCaretToTextStart : ActionTask<InputField>
    {       
        public BBParameter<bool> shift;
        protected override void OnExecute()
        {
            agent.MoveTextStart(shift.value);
            EndAction();
        }
    }
}