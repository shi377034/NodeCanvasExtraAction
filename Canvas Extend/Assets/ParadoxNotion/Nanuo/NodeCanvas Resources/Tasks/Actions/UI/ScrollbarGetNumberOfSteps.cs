using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Get NumberOfSteps")]
    [Category("UI/Scrollbar")]
    public class ScrollbarGetNumberOfSteps : ActionTask<Scrollbar>
    {
        [BlackboardOnly]
        public BBParameter<int> numberOfSteps;
        protected override void OnExecute()
        {
            numberOfSteps.value = agent.numberOfSteps;
            EndAction();
        }
    }
}