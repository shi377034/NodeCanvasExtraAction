using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions{

	[Category("Device")]
	public class CheckDeviceShake : ConditionTask{

		public BBParameter<float> shakeThreshold = 3f;

		protected override bool OnCheck(){
            var acceleration = Input.acceleration;
            if (acceleration.sqrMagnitude > (shakeThreshold.value * shakeThreshold.value))
            {
                return true;
            }
            return false;
		}
	}
}