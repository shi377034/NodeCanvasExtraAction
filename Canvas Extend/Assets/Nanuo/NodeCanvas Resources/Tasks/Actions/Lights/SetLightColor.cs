using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions{

	[Category("Lights")]
	public class SetLightColor : ActionTask<Light>{
        public BBParameter<Color> lightColor;
        protected override void OnExecute(){
            agent.color = lightColor.value;
            EndAction();
		}
	}
}