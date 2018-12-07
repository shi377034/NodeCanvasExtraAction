using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions{

	[Name("Check Current State Loop Count")]
	[Category("Animator")]
	public class MecanimCheckCurrentStateLoopCount : ConditionTask<Animator> {
        public BBParameter<int> layerIndex;
        public CompareMethod comparison = CompareMethod.EqualTo;
		public BBParameter<int> value;
        [BlackboardOnly]
        public BBParameter<int> LoopCount;
        private int loopCount;
        protected override string info{
			get
			{
				return string.Format("Mec.Layer'{0}'.CurrentState.LoopCount'{1}'", layerIndex, loopCount) + OperationTools.GetCompareString(comparison) + value;
			}
		}

		protected override bool OnCheck(){
            AnimatorStateInfo _info = agent.GetCurrentAnimatorStateInfo(layerIndex.value);
            loopCount = (int)System.Math.Truncate(_info.normalizedTime);
            LoopCount.value = loopCount;
            return OperationTools.Compare(loopCount,value.value, comparison);
		}
	}
}