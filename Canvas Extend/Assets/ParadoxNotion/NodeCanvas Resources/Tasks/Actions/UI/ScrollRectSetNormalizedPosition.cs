using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Set NormalizedPosition")]
    [Category("UI/ScrollRect")]
    public class ScrollRectSetNormalizedPosition : ActionTask<ScrollRect>
    {
        public BBParameter<Vector2> normalizedPosition;
        protected override void OnExecute()
        {
            agent.normalizedPosition = normalizedPosition.value;
            EndAction();
        }
    }
}