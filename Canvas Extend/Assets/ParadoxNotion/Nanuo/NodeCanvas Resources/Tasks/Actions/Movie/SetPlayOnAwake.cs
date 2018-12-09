using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.Video;

namespace NodeCanvas.Tasks.Actions{

	[Category("Movie")]
	public class SetPlayOnAwake : ActionTask<VideoPlayer>{
        public BBParameter<bool> playOnAwake;
        protected override void OnExecute(){
            agent.playOnAwake = playOnAwake.value;
            EndAction();
		}
	}
}