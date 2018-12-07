using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions{

	[Name("Check Current State Loop Progress")]
	[Category("Animator")]
	public class MecanimCheckCurrentStateLoopProgress : ConditionTask<Animator> {
        public BBParameter<int> layerIndex;
        public CompareMethod comparison = CompareMethod.EqualTo;
		public BBParameter<float> value;
        [BlackboardOnly]
        public BBParameter<float> LoopProgress;
        private float _currentLoopProgress;
        private int loopCount;
        protected override string info{
			get
			{
				return string.Format("Mec.Layer'{0}'.CurrentState.LoopProgress'{1}'", layerIndex, _currentLoopProgress) + OperationTools.GetCompareString(comparison) + value;
			}
		}

		protected override bool OnCheck(){
            AnimatorStateInfo _info = agent.GetCurrentAnimatorStateInfo(layerIndex.value);
            loopCount = (int)System.Math.Truncate(_info.normalizedTime);
            _currentLoopProgress = _info.normalizedTime - loopCount;
            LoopProgress.value = _currentLoopProgress;
            return OperationTools.Compare(_currentLoopProgress, (float)value.value, comparison, 0.1f);
		}
	}
}