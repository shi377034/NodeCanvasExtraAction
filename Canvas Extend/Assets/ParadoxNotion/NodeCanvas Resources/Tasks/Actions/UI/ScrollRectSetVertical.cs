using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Set Vertical")]
    [Category("UI/ScrollRect")]
    public class ScrollRectSetVertical : ActionTask<ScrollRect>
    {
        public BBParameter<bool> vertical;
        protected override void OnExecute()
        {
            agent.vertical = vertical.value;
            EndAction();
        }
    }
}