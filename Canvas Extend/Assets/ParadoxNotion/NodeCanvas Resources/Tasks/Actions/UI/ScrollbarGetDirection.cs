using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Get Direction")]
    [Category("UI/Scrollbar")]
    public class ScrollbarGetDirection : ActionTask<Scrollbar>
    {
        [BlackboardOnly]
        public BBParameter<Scrollbar.Direction> direction;
        protected override void OnExecute()
        {
            direction.value = agent.direction;
            EndAction();
        }
    }
}