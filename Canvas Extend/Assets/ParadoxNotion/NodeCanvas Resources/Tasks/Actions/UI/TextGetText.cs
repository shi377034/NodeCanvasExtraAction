using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Get Text")]
    [Category("UI/Text")]
    public class TextGetText : ActionTask<Text>
    {
        [BlackboardOnly]
        public BBParameter<string> text;
        protected override void OnExecute()
        {
            text.value = agent.text;
            EndAction();
        }
    }
}