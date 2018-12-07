using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Do Nothing")]
    public class Empty : ActionTask
    {
        protected override string info
        {
            get { return "Do Nothing"; }
        }
        protected override void OnExecute()
        {
            EndAction();
        }
    }
}