using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Get PlaceHolder")]
    [Category("UI/InputField")]
    public class InputFieldGetPlaceHolder : ActionTask<InputField>
    {
        [BlackboardOnly]
        public BBParameter<GameObject> placeHolder;
        protected override void OnExecute()
        {
            placeHolder.value = agent.placeholder.gameObject;
            EndAction();
        }
    }
}