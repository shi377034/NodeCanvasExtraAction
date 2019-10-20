using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.Video;

namespace NodeCanvas.Tasks.Actions{

	[Category("Movie")]
	public class PlayMovie : ActionTask<VideoPlayer>{
       
        protected override void OnExecute(){
            agent.Play();
            EndAction();
		}
	}
}