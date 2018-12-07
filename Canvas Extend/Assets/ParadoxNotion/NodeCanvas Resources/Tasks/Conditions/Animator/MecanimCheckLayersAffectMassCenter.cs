using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions
{

    [Name("Check LayersAffectMassCenter")]
    [Category("Animator")]
    public class MecanimCheckLayersAffectMassCenter : ConditionTask<Animator>
    {
        public BBParameter<bool> value;

        protected override string info
        {
            get { return "Mec.layersAffectMassCenter == " + value; }
        }

        protected override bool OnCheck()
        {
            return agent.layersAffectMassCenter == value.value;
        }
    }
}