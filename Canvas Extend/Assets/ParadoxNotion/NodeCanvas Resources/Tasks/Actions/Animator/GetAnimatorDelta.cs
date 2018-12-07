using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{
    [Name("Get Delta")]
    [Category("Animator")]
    public class GetAnimatorDelta : ActionTask<Animator>
    {
        public BBParameter<Vector3> deltaPosition;
        public BBParameter<Quaternion> deltaRotation;
        protected override void OnExecute()
        {
            deltaPosition.value = agent.deltaPosition;
            deltaRotation.value = agent.deltaRotation;
            EndAction();
        }
    }
}