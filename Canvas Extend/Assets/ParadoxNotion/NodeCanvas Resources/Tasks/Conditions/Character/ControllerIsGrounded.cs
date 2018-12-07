using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions{

	[Name("Check Is Grounded")]
	[Category("Character")]
	public class ControllerIsGrounded : ConditionTask<CharacterController> {
		public BBParameter<bool> value;
		protected override string info{
			get{return "Character.isGrounded == " + value;}
		}

		protected override bool OnCheck(){
			return agent.isGrounded == value.value;
		}
	}
}