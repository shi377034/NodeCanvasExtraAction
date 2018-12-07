using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Set Direction")]
    [Category("UI/Scrollbar")]
    public class ScrollbarSetDirection : ActionTask<Scrollbar>
    {
        public BBParameter<Scrollbar.Direction> direction = Scrollbar.Direction.LeftToRight;
        protected override void OnExecute()
        {
            agent.direction = direction.value;
            EndAction();
        }
    }
}