using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions{

	[Name("Check Mute")]
	[Category("Audio")]
	public class AudioCheckMute : ConditionTask<AudioSource> {

		public BBParameter<bool> value;

		protected override string info{
			get{return "Audio.Mute == " + value;}
		}

		protected override bool OnCheck(){
			return agent.mute == value.value;
		}
	}
}