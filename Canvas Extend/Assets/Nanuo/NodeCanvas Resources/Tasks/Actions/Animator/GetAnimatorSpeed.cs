using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{
    [Name("Get Speed")]
    [Category("Animator")]
    public class GetAnimatorSpeed : ActionTask<Animator>
    {
        [BlackboardOnly]
        public BBParameter<float> speed;
        protected override string info {
            get
            {
                return string.Format("{0} = speed", speed);
            }
        }
        protected override void OnExecute()
        {
            speed.value = agent.speed;
            EndAction();
        }
    }
}