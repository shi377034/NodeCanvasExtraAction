using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Get WasCanceled")]
    [Category("UI/InputField")]
    public class InputFieldGetWasCanceled : ActionTask<InputField>
    {
        [BlackboardOnly]
        public BBParameter<bool> wasCanceled;
        protected override void OnExecute()
        {
            wasCanceled.value = agent.wasCanceled;
            EndAction();
        }
    }
}