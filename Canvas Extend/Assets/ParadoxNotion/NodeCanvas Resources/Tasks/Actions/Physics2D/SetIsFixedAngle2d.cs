using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{

	[Category("Physics2D")]
	public class SetIsFixedAngle2d : ActionTask<Rigidbody2D>
    {
        public BBParameter<bool> isFixedAngle;
        protected override void OnExecute(){
#if UNITY_5_3_5 || UNITY_5_4_OR_NEWER
            if (isFixedAngle.value)
            {
                agent.constraints = agent.constraints | RigidbodyConstraints2D.FreezeRotation;
            }
            else
            {
                agent.constraints = agent.constraints & ~RigidbodyConstraints2D.FreezeRotation;
            }
#else
			agent.fixedAngle = isFixedAngle.value;
#endif
            EndAction();
		}
	}
}