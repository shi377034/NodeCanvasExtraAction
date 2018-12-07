using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions{

	[Category("Vector2")]
	[Description("Set a blackboard Vector2 variable")]
	public class SetVector2 : ActionTask {

		[BlackboardOnly]
		public BBParameter<Vector2> valueA;
		public OperationMethod operation;
		public BBParameter<Vector2> valueB;
		public bool perSecond;

		protected override string info{
			get	{return string.Format("{0} {1} {2}{3}", valueA, OperationTools.GetOperationString(operation), valueB, (perSecond? " Per Second" : "") );}
		}

		protected override void OnExecute(){
			valueA.value = OperationTools.Operate(valueA.value, valueB.value, operation, perSecond? Time.deltaTime : 1f );
			EndAction();
		}
	}
}