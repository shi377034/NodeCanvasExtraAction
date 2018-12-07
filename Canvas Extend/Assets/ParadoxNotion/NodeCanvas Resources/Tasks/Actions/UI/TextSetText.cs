using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Set Text")]
    [Category("UI/Text")]
    public class TextSetText : ActionTask<Text>
    {
        public BBParameter<string> text;
        protected override void OnExecute()
        {
            agent.text = text.value;
            EndAction();
        }
    }
}