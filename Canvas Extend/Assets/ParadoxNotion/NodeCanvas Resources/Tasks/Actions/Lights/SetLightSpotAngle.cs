using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions{

	[Category("Lights")]
	public class SetLightSpotAngle : ActionTask<Light>{
        public BBParameter<float> lightSpotAngle = 20f;
        protected override void OnExecute(){
            agent.spotAngle = lightSpotAngle.value;
            EndAction();
		}
	}
}