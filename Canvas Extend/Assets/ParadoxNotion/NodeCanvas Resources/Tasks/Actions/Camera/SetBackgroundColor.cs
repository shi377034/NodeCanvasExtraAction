using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions{
	[Category("Camera")]
	public class SetBackgroundColor : ActionTask<Camera>
    {
        public BBParameter<Color> backgroundColor;
        protected override void OnExecute(){
            agent.backgroundColor = backgroundColor.value;
            EndAction();
        }
    }
}