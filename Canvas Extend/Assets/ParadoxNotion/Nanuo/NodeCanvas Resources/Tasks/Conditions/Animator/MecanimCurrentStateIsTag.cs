using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions{

	[Name("Current State IsTag")]
	[Category("Animator")]
	public class MecanimCurrentStateIsTag : ConditionTask<Animator> {

        public BBParameter<int> layerIndex;
        [RequiredField]
        public BBParameter<string> stateTag;
		protected override string info{
			get{return string.Format("Mec.Layer '{0}'.Current State IsTag({1})", layerIndex, stateTag);}
		}

		protected override bool OnCheck(){
            AnimatorStateInfo _info = agent.GetCurrentAnimatorStateInfo(layerIndex.value);
            return _info.IsTag(stateTag.value);
		}
	}
}