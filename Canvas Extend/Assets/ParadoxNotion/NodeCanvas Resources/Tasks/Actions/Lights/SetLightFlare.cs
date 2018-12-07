using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions{

	[Category("Lights")]
	public class SetLightFlare : ActionTask<Light>{
        public BBParameter<Flare> lightFlare;
        protected override void OnExecute(){
            agent.flare = lightFlare.value;
            EndAction();
		}
	}
}