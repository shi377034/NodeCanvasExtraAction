using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions{

	[Name("Is In Transition UserName")]
	[Category("Animator")]
	public class MecanimIsInTransitionIsUserName : ConditionTask<Animator> {

		public BBParameter<int> layerIndex;
        [RequiredField]
        public BBParameter<string> userName;

        protected override string info{
			get {return string.Format("Mec.Is In Transition userName'{0}'", userName);}
		}

		protected override bool OnCheck(){
            AnimatorTransitionInfo _info = agent.GetAnimatorTransitionInfo(layerIndex.value);
            return _info.IsUserName(userName.value);
		}
	}
}