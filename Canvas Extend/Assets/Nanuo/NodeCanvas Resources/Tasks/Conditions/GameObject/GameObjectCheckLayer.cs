using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions{

	[Name("Check Layer")]
	[Category("GameObject")]
	public class GameObjectCheckLayer : ConditionTask<GameObject> {

		public BBParameter<LayerMask> value;

		protected override string info{
			get{return "GameObject.Layer == " + value;}
		}

		protected override bool OnCheck(){
			return agent.layer == value.value;
		}
	}
}