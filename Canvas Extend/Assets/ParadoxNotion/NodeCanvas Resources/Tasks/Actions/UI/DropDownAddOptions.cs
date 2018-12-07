using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("AddOptions")]
    [Category("UI/DropDown")]
    public class DropDownAddOptions : ActionTask<Dropdown>
    {
        [System.Serializable]
        public class OptionData
        {
            public string text;
            public Sprite image;
        }
        [Name("Options")]
        public BBParameter<OptionData[]> optionText;
        protected override void OnExecute()
        {
           var options = new List<Dropdown.OptionData>();
            foreach(var option in optionText.value)
            {
                options.Add(new Dropdown.OptionData()
                {
                    text = option.text,
                    image = option.image
                });
            }
            agent.AddOptions(options);
            EndAction();
        }
    }
}