using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions{

	[Category("Lights")]
	public class SetLightCookie : ActionTask<Light>{
        public BBParameter<Texture> lightCookie;
        protected override void OnExecute(){
            agent.cookie = lightCookie.value;
            EndAction();
		}
	}
}