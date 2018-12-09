using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions{
	[Category("Physics")]
	public class CheckIsKinematic : ConditionTask<Rigidbody>{
        protected override bool OnCheck(){
			return agent.isKinematic;					
		}
    } 
}