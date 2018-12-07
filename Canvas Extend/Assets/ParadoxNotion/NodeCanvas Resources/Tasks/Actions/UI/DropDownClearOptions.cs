using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("ClearOptions")]
    [Category("UI/DropDown")]
    public class DropDownClearOptions : ActionTask<Dropdown>
    {
        protected override void OnExecute()
        { 
            agent.ClearOptions();
            EndAction();
        }
    }
}