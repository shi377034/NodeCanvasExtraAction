using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions{

	[Category("Vector")]
	public class CheckVectorSqrMagnitude : ConditionTask{

		[BlackboardOnly]
		public BBParameter<Vector3> vectorA;
		public CompareMethod comparison = CompareMethod.EqualTo;
		public BBParameter<float> valueB;

		protected override string info{
			get	{return string.Format("{0}.sqrMagnitude {1} {2}", vectorA, OperationTools.GetCompareString(comparison), valueB);}
		}

		protected override bool OnCheck(){
			return OperationTools.Compare(vectorA.value.sqrMagnitude, valueB.value, comparison, 0f);
		}
	}
}