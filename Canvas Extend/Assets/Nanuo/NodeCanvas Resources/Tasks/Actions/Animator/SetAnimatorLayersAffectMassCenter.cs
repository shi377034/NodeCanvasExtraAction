using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{
    [Name("Set LayersAffectMassCenter")]
    [Category("Animator")]
    public class SetAnimatorLayersAffectMassCenter : ActionTask<Animator>
    {
        public BBParameter<bool> affectMassCenter;
        protected override string info
        {
            get
            {
                return "Animator.layersAffectMassCenter = " + affectMassCenter;
            }
        }
        protected override void OnExecute()
        {
            agent.layersAffectMassCenter = affectMassCenter.value;
            EndAction();
        }
    }
}