using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions{

	[Category("Lights")]
	public class SetLightRange : ActionTask<Light>{
        public BBParameter<float> lightRange = 20f;
        protected override void OnExecute(){
            agent.range = lightRange.value;
            EndAction();
		}
	}
}