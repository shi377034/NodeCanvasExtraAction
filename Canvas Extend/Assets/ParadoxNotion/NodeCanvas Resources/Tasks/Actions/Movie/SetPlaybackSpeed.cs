using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.Video;

namespace NodeCanvas.Tasks.Actions{

	[Category("Movie")]
	public class SetPlaybackSpeed : ActionTask<VideoPlayer>{
        public BBParameter<float> playbackSpeed;
        protected override void OnExecute(){
            agent.playbackSpeed = playbackSpeed.value;
            EndAction();
		}
	}
}