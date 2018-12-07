using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions{

	[Name("Next State IsName")]
	[Category("Animator")]
	public class MecanimNextStateIsName : ConditionTask<Animator> {

        public BBParameter<int> layerIndex;
        [RequiredField]
        public BBParameter<string> stateName;
		protected override string info{
			get{return string.Format("Mec.Layer '{0}'.Next State IsName({1})", layerIndex, stateName);}
		}

		protected override bool OnCheck(){
            AnimatorStateInfo _info = agent.GetNextAnimatorStateInfo(layerIndex.value);
            return _info.IsName(stateName.value);
		}
	}
}