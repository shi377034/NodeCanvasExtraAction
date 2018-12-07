using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.Video;

namespace NodeCanvas.Tasks.Actions{

	[Category("Movie")]
	public class SetMovieClip : ActionTask<VideoPlayer>{
       
        public BBParameter<VideoClip> videoClip;
        protected override void OnExecute(){
            agent.clip = videoClip.value;
            EndAction();
		}
	}
}