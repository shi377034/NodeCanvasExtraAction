using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Set NumberOfSteps")]
    [Category("UI/Scrollbar")]
    public class ScrollbarSetNumberOfSteps : ActionTask<Scrollbar>
    {
        public BBParameter<int> numberOfSteps;
        protected override void OnExecute()
        {
            agent.numberOfSteps = numberOfSteps.value;
            EndAction();
        }
    }
}