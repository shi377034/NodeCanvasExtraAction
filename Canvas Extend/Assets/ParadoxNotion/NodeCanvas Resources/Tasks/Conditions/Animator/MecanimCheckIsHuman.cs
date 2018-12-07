using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions
{

    [Name("Check Is Human")]
    [Category("Animator")]
    public class MecanimCheckIsHuman : ConditionTask<Animator>
    {
        public BBParameter<bool> value;

        protected override string info
        {
            get { return "Mec.isHuman == " + value; }
        }

        protected override bool OnCheck()
        {
            return agent.isHuman == value.value;
        }
    }
}