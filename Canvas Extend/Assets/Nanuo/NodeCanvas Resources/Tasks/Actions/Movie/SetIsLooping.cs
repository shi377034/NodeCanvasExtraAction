using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.Video;

namespace NodeCanvas.Tasks.Actions{

	[Category("Movie")]
	public class SetIsLooping : ActionTask<VideoPlayer>{
        public BBParameter<bool> isLooping;
        protected override void OnExecute(){
            agent.isLooping = isLooping.value;
            EndAction();
		}
	}
}