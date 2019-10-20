using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions{

	[Name("Check ChildCount")]
	[Category("GameObject")]
	public class GameObjectCheckChildCount : ConditionTask<Transform> {
        public CompareMethod comparison = CompareMethod.EqualTo;
        public BBParameter<int> value;

		protected override string info{
			get{ return "Child Count " + OperationTools.GetCompareString(comparison) + value; }
		}

		protected override bool OnCheck(){
			return OperationTools.Compare(agent.childCount,value.value, comparison);
		}
	}
}