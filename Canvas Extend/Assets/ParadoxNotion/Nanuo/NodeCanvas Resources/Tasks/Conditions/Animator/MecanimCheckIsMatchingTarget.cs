using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions
{

    [Name("Check Is MatchingTarget")]
    [Category("Animator")]
    public class MecanimCheckIsMatchingTarget : ConditionTask<Animator>
    {
        public BBParameter<bool> value;

        protected override string info
        {
            get { return "Mec.isMatchingTarget == " + value; }
        }

        protected override bool OnCheck()
        {
            return agent.isMatchingTarget == value.value;
        }
    }
}