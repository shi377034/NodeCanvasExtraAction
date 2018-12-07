using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions{

	[Category("Lights")]
	public class SetLightIntensity : ActionTask<Light>{
        public BBParameter<float> lightIntensity = 1f;
        protected override void OnExecute(){
            agent.intensity = lightIntensity.value;
            EndAction();
		}
	}
}