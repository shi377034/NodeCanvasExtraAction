using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using DG.Tweening;
namespace NodeCanvas.Tasks.Actions{

	[Category("Camera")]
	public class ShakeCamera : ActionTask<Camera>
    {
        public enum ShakeMode
        {
            PositionFloat,
            PositionVector3,
            RotationFloat,
            RotationVector3
        }
        public ShakeMode mode = ShakeMode.PositionFloat;
        public BBParameter<float> duration = 0.25f;
        [ShowIf("mode", (int)ShakeMode.PositionFloat | (int)ShakeMode.RotationFloat)]
        public BBParameter<float> strength = 3f;
        [ShowIf("mode", (int)ShakeMode.PositionVector3 | (int)ShakeMode.RotationVector3)]
        public BBParameter<Vector3> strengthVector3;
        public BBParameter<int> vibrato = 10;
        public BBParameter<float> randomness = 90f;
        public BBParameter<bool> fadeOut = true;
        protected override void OnExecute(){
            switch(mode)
            {
                case ShakeMode.PositionFloat:
                    agent.DOShakePosition(duration.value, strength.value, vibrato.value, randomness.value, fadeOut.value);
                    break;
                case ShakeMode.PositionVector3:
                    agent.DOShakePosition(duration.value, strengthVector3.value, vibrato.value, randomness.value, fadeOut.value);
                    break;
                case ShakeMode.RotationFloat:
                    agent.DOShakeRotation(duration.value, strength.value, vibrato.value, randomness.value, fadeOut.value);
                    break;
                case ShakeMode.RotationVector3:
                    agent.DOShakeRotation(duration.value, strengthVector3.value, vibrato.value, randomness.value, fadeOut.value);
                    break;
            }
            EndAction();
        }
    }
}