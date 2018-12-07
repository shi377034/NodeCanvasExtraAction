using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Set Horizontal")]
    [Category("UI/ScrollRect")]
    public class ScrollRectSetHorizontal : ActionTask<ScrollRect>
    {
        public BBParameter<bool> horizontal;
        protected override void OnExecute()
        {
            agent.horizontal = horizontal.value;
            EndAction();
        }
    }
}