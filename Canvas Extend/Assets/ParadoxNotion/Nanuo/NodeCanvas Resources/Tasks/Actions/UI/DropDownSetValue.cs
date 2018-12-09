using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Set Value")]
    [Category("UI/DropDown")]
    public class DropDownSetValue : ActionTask<Dropdown>
    {
        public BBParameter<int> value;
        protected override void OnExecute()
        {
            agent.value = value.value;
            EndAction();
        }
    }
}