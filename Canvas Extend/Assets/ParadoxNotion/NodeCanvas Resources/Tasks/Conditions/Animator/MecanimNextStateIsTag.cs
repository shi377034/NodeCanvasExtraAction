using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions{

	[Name("Next State IsTag")]
	[Category("Animator")]
	public class MecanimNextStateIsTag : ConditionTask<Animator> {

        public BBParameter<int> layerIndex;
        [RequiredField]
        public BBParameter<string> stateTag;
		protected override string info{
			get{return string.Format("Mec.Layer '{0}'.Next State IsTag({1})", layerIndex, stateTag);}
		}

		protected override bool OnCheck(){
            AnimatorStateInfo _info = agent.GetNextAnimatorStateInfo(layerIndex.value);
            return _info.IsTag(stateTag.value);
		}
	}
}