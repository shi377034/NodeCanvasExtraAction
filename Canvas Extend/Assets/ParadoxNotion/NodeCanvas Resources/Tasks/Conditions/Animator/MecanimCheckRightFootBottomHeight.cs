using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions{

	[Name("Check RightFootBottomHeight")]
	[Category("Animator")]
	public class MecanimCheckRightFootBottomHeight : ConditionTask<Animator> {
		public CompareMethod comparison = CompareMethod.EqualTo;
		public BBParameter<float> value;

		protected override string info{
			get
			{
				return "Mec.rightFeetBottomHeight " + OperationTools.GetCompareString(comparison) + value;
			}
		}

		protected override bool OnCheck(){

			return OperationTools.Compare( agent.rightFeetBottomHeight, (float)value.value, comparison, 0.1f);
		}
	}
}