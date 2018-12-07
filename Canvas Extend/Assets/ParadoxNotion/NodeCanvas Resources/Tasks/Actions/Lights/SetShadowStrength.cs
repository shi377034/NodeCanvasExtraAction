using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions{

	[Category("Lights")]
	public class SetShadowStrength : ActionTask<Light>{
        public BBParameter<float> shadowStrength = 0.8f;
        protected override void OnExecute(){
            agent.shadowStrength = shadowStrength.value;
            EndAction();
		}
	}
}