using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions{

	[Category("Math")]
	public class FloatClamp : ActionTask<Renderer>{
        public BBParameter<float> variable;
        public BBParameter<float> minValue;
        public BBParameter<float> maxValue;

        protected override void OnExecute(){
            variable.value = Mathf.Clamp(variable.value, minValue.value, maxValue.value);
            EndAction();
		}
	}
}