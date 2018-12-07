using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions{

	[Name("Is In Transition Name")]
	[Category("Animator")]
	public class MecanimIsInTransitionIsName : ConditionTask<Animator> {

		public BBParameter<int> layerIndex;
        [RequiredField]
        public BBParameter<string> transitionName;

        protected override string info{
			get {return string.Format("Mec.Is In Transition'{0}'", transitionName);}
		}

		protected override bool OnCheck(){
            AnimatorTransitionInfo _info = agent.GetAnimatorTransitionInfo(layerIndex.value);
            return _info.IsName(transitionName.value);
		}
	}
}