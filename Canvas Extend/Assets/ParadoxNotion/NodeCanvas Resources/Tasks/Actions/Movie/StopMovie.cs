using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.Video;

namespace NodeCanvas.Tasks.Actions{

	[Category("Movie")]
	public class StopMovie : ActionTask<VideoPlayer>{
       
        protected override void OnExecute(){
            agent.Stop();
            EndAction();
		}
	}
}