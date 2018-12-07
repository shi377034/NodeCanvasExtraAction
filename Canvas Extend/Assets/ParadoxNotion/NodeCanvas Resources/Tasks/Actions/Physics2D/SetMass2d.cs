using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{

	[Category("Physics2D")]
	public class SetMass2d : ActionTask<Rigidbody2D>
    {
        [SliderField(0.1f,10f)]
        public BBParameter<float> mass = 1f;   
        protected override void OnExecute(){
            agent.mass = mass.value;
            EndAction();
		}
	}
}