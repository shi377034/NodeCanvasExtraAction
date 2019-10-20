using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("NavMeshAgent Synchronizer")]
    [Category("Animator")]
    [EventReceiver("OnAnimatorMove")]
    public class NavMeshAgentAnimatorSynchronizer : ActionTask<Animator>
    {
        [RequiredField]
        public BBParameter<NavMeshAgent> navMeshAgent;
        protected override string info
        {
            get
            {
                return navMeshAgent + " Synchronizer";
            }
        }
        public void OnAnimatorMove()
        {
            navMeshAgent.value.velocity = agent.deltaPosition / Time.deltaTime;
            navMeshAgent.value.transform.rotation = agent.rootRotation;
            EndAction();
        }
    }
}