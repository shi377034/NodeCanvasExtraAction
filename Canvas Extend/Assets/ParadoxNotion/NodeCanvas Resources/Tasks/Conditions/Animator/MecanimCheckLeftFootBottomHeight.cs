using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions{

	[Name("Check LeftFootBottomHeight")]
	[Category("Animator")]
	public class MecanimCheckLeftFootBottomHeight : ConditionTask<Animator> {
		public CompareMethod comparison = CompareMethod.EqualTo;
		public BBParameter<float> value;

		protected override string info{
			get
			{
				return "Mec.leftFeetBottomHeight " + OperationTools.GetCompareString(comparison) + value;
			}
		}

		protected override bool OnCheck(){

			return OperationTools.Compare( agent.leftFeetBottomHeight, (float)value.value, comparison, 0.1f);
		}
	}
}