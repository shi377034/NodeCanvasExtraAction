using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions
{

    [Name("Check Is ParameterControlledByCurve")]
    [Category("Animator")]
    public class MecanimCheckIsParameterControlledByCurve : ConditionTask<Animator>
    {
        [RequiredField]
        public BBParameter<string> parameterName;
        public BBParameter<bool> value;

        protected override string info
        {
            get { return string.Format("Mec.'{0}'ControlledByCurve == {1}", parameterName, value); }
        }

        protected override bool OnCheck()
        {
            return agent.IsParameterControlledByCurve(parameterName.value) == value.value;
        }
    }
}