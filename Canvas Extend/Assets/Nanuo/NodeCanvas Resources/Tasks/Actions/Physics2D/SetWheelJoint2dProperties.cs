using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{

	[Category("Physics2D")]
	public class SetWheelJoint2dProperties : ActionTask<WheelJoint2D>
    {
        public BBParameter<bool> useMotor;
        public BBParameter<float> motorSpeed;
        public BBParameter<float> maxMotorTorque;
        public BBParameter<float> angle;
        public BBParameter<float> dampingRatio;
        public BBParameter<float> frequency;
        JointMotor2D _motor;
        JointSuspension2D _suspension;
        protected override void OnExecute(){
            _motor = agent.motor;
            _suspension = agent.suspension;
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

            _suspension.angle = angle.value;
            agent.suspension = _suspension;

            _suspension.dampingRatio = dampingRatio.value;
            agent.suspension = _suspension;

            _suspension.frequency = frequency.value;
            agent.suspension = _suspension;
        }
    }
}