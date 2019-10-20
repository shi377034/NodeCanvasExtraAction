using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions{

	[Name("Set Look At Super")]
	[Category("Animator")]
	[EventReceiver("OnAnimatorIK")]
	public class SetAnimatorLookAt : ActionTask<Animator> {

		public BBParameter<GameObject> target;
        public BBParameter<Vector3> targetPosition;
        [SliderField(0,1f)]
        public BBParameter<float> weight = 1.0f;
        [SliderField(0, 1f)]
        public BBParameter<float> bodyWeight = 0.3f;
        [SliderField(0, 1f)]
        public BBParameter<float> headWeight = 0.6f;
        [SliderField(0, 1f)]
        public BBParameter<float> eyesWeight = 1f;
        [SliderField(0, 1f)]
        public BBParameter<float> clampWeight = 0.5f;

        protected override string info{
			get{return "Mec.SetLookAt " + target; }
		}

		public void OnAnimatorIK(){
            if(target.value != null)
            {
                agent.SetLookAtPosition(target.value.transform.position + targetPosition.value);
            }else
            {
                agent.SetLookAtPosition(targetPosition.value);
            }
            agent.SetLookAtWeight(weight.value, bodyWeight.value, headWeight.value, eyesWeight.value, clampWeight.value);

            EndAction();
		}
	}
}