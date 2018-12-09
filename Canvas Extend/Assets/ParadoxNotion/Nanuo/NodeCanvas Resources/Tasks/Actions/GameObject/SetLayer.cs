using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions{

	[Category("GameObject")]
	public class SetLayer : ActionTask<GameObject>{
        public BBParameter<LayerMask> layer;
        protected override void OnExecute(){
            agent.layer = layer.value;
            EndAction();
		}
	}
}