using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions{

	[Name("Check CollisionFlags")]
	[Category("Character")]
	public class CheckControllerCollisionFlags : ConditionTask<CharacterController> {
		public BBParameter<CollisionFlags> value;

		protected override string info{
			get{return "Character.collisionFlags == " + value;}
		}

		protected override bool OnCheck(){

			return agent.collisionFlags == value.value;
		}
	}
}