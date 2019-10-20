using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.Video;

namespace NodeCanvas.Tasks.Actions{

	[Category("Movie")]
	public class SetWaitForFirstFrame : ActionTask<VideoPlayer>{
        public BBParameter<bool> waitForFirstFrame;
        protected override void OnExecute(){
            agent.waitForFirstFrame = waitForFirstFrame.value;
            EndAction();
		}
	}
}