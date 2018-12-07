using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions{

	[Name("Check ApplyMotionRoot")]
	[Category("Animator")]
	public class MecanimCheckApplyMotionRoot : ConditionTask<Animator> {

		public BBParameter<bool> value;

		protected override string info{
			get{return "Mec.applyRootMotion == " + value;}
		}

		protected override bool OnCheck(){

			return agent.applyRootMotion == value.value;
		}
	}
}