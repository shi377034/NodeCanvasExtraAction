using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions{

	[Category("Math")]
	public class IntClamp : ActionTask<Renderer>{
        public BBParameter<int> variable;
        public BBParameter<int> minValue;
        public BBParameter<int> maxValue;

        protected override void OnExecute(){
            variable.value = Mathf.Clamp(variable.value, minValue.value, maxValue.value);
            EndAction();
		}
	}
}