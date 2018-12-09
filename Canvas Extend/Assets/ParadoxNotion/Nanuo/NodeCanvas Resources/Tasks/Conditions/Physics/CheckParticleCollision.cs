using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions{
	[Category("Physics")]
    [EventReceiver("OnParticleCollision")]
	public class CheckParticleCollision : ConditionTask{
        public BBParameter<GameObject> other;
        protected override bool OnCheck(){
			return false;					
		}
        public void OnParticleCollision(GameObject other)
        {
            this.other.value = other;
            YieldReturn(true);
        }
    } 
}