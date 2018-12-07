using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions{

	[Category("GameObject")]
	public class SetLayersOnChildren : ActionTask<Transform>{
        public BBParameter<LayerMask> layer;
        protected override void OnExecute(){
            foreach(Transform child in agent)
            {
                child.gameObject.layer = layer.value;
            }
            EndAction();
		}
	}
}