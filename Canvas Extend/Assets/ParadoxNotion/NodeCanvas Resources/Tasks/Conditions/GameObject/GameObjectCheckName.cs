using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions{

	[Name("Check Name")]
	[Category("GameObject")]
	public class GameObjectCheckName : ConditionTask<GameObject> {

		public BBParameter<string> value;

		protected override string info{
			get{return "GameObject.Name == " + value;}
		}

		protected override bool OnCheck(){
			return agent.name == value.value;
		}
	}
}