using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{

	[Category("Material")]
	public class SetVisibility : ActionTask<Renderer>{
        public BBParameter<bool> toggle;
        public BBParameter<bool> visible;
        protected override void OnExecute(){
            // if 'toggle' is not set, simply sets visibility to new value
            if (!toggle.value)
            {
                agent.enabled = visible.value;
                EndAction();
                return;
            }

            // otherwise, toggles the visibility
            agent.enabled = !agent.enabled;
            EndAction();
		}
	}
}