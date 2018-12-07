using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{

	[Category("Physics2D")]
	public class SetHingeJoint2dProperties : ActionTask<HingeJoint2D>
    {
        public BBParameter<bool> useLimits;
        public BBParameter<float> min;
        public BBParameter<float> max;
        public BBParameter<bool> useMotor;
        public BBParameter<float> motorSpeed;
        public BBParameter<float> maxMotorTorque;

        JointMotor2D _motor;
        JointAngleLimits2D _limits;
        protected override void OnExecute(){
            _motor = agent.motor;
            _limits = agent.limits;
            SetProperties();
            EndAction();
		}
        void SetProperties()
        {
            agent.useMotor = useMotor.value;

            _motor.motorSpeed = motorSpeed.value;
            agent.motor = _motor;

            _motor.maxMotorTorque = maxMotorTorque.value;
            agent.motor = _motor;

            agent.useLimits = useLimits.value;

            _limits.min = min.value;
            agent.limits = _limits;

            _limits.max = max.value;
            agent.limits = _limits;
        }
    }
}