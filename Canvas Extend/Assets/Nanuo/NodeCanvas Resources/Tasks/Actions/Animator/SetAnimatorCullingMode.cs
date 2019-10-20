using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{
    [Name("Set CullingMode")]
    [Category("Animator")]
    public class SetAnimatorCullingMode : ActionTask<Animator>
    {
        public BBParameter<AnimatorCullingMode> cullingMode;
        protected override string info {
            get
            {
                return "Animator.cullingMode = " + cullingMode;
            }
        }
        protected override void OnExecute()
        {
            agent.cullingMode = cullingMode.value;
            EndAction();
        }
    }
}
