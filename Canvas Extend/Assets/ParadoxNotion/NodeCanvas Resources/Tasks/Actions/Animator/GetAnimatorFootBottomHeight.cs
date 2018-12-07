using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{
    [Name("Get FootBottomHeight")]
    [Category("Animator")]
    public class GetAnimatorFootBottomHeight : ActionTask<Animator>
    {
        [BlackboardOnly]
        public BBParameter<float> leftFootHeight;
        [BlackboardOnly]
        public BBParameter<float> rightFootHeight;
        [BlackboardOnly]
        public BBParameter<Vector2> saveAs;
        protected override void OnExecute()
        {
            leftFootHeight.value = agent.leftFeetBottomHeight;
            rightFootHeight.value = agent.rightFeetBottomHeight;
            saveAs.value = new Vector2(agent.leftFeetBottomHeight, agent.rightFeetBottomHeight);
            EndAction();
        }
    }
}