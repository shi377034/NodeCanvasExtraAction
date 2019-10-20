using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("MoveTextEnd")]
    [Category("UI/InputField")]
    public class InputFieldMoveCaretToTextEnd : ActionTask<InputField>
    {       
        public BBParameter<bool> shift;
        protected override void OnExecute()
        {
            agent.MoveTextEnd(shift.value);
            EndAction();
        }
    }
}