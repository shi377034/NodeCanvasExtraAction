using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions{

	[Name("Check CullingMode")]
	[Category("Animator")]
	public class MecanimCheckCullingMode : ConditionTask<Animator> {

		public BBParameter<AnimatorCullingMode> value;

		protected override string info{
			get{return "Mec.cullingMode == " + value;}
		}

		protected override bool OnCheck(){

			return agent.cullingMode == value.value;
		}
	}
}