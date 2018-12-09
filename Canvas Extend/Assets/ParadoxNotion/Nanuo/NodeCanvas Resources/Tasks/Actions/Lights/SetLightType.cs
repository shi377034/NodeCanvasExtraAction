using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions{

	[Category("Lights")]
	public class SetLightType : ActionTask<Light>{
        public BBParameter<LightType> lightType = LightType.Point;
        protected override void OnExecute(){
            agent.type = lightType.value;
            EndAction();
		}
	}
}