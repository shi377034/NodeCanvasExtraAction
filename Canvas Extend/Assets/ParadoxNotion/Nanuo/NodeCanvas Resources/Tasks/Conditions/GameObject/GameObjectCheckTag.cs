using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions{

	[Name("Check Tag")]
	[Category("GameObject")]
	public class GameObjectCheckTag : ConditionTask<GameObject> {

        [TagField]
		public BBParameter<string> value;

		protected override string info{
			get{return "GameObject.Tag == " + value;}
		}

		protected override bool OnCheck(){
			return agent.tag == value.value;
		}
	}
}