using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Get SelectedData")]
    [Category("UI/DropDown")]
    public class DropDownGetSelectedData : ActionTask<Dropdown>
    {
        [BlackboardOnly]
        public BBParameter<int> index;
        [BlackboardOnly]
        public BBParameter<string> text;
        [BlackboardOnly]
        public BBParameter<Sprite> image;
        protected override void OnExecute()
        {
            if (agent.options.Count > 0)
            {
                index.value = agent.value;
                text.value = agent.options[agent.value].text;
                image.value = agent.options[agent.value].image;
            }
            EndAction();
        }
    }
}