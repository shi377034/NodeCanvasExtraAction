using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions{

	[Category("Input")]
	public class MouseLook2 : ActionTask<Rigidbody> {
        public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
        [Tooltip("The axes to rotate around.")]
        public RotationAxes axes = RotationAxes.MouseXAndY;
        public BBParameter<float> sensitivityX = 15f;
        public BBParameter<float> sensitivityY = 15f;
        [SliderField(-360f, 360f)]
        public BBParameter<float> minimumX = -360f;
        [SliderField(-360f, 360f)]
        public BBParameter<float> maximumX = 360f;
        [SliderField(-360f, 360f)]
        public BBParameter<float> minimumY = -60f;
        [SliderField(-360f, 360f)]
        public BBParameter<float> maximumY = 60f;
        float rotationX;
        float rotationY;

        protected override void OnExecute(){
            agent.freezeRotation = true;
            rotationX = agent.transform.localRotation.eulerAngles.y;
            rotationY = agent.transform.localRotation.eulerAngles.x;
            DoMouseLook();
            EndAction();
        }
        void DoMouseLook()
        {
            var transform = agent.transform;

            switch (axes)
            {
                case RotationAxes.MouseXAndY:

                    transform.localEulerAngles = new Vector3(GetYRotation(), GetXRotation(), 0);
                    break;

                case RotationAxes.MouseX:

                    transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, GetXRotation(), 0);
                    break;

                case RotationAxes.MouseY:

                    transform.localEulerAngles = new Vector3(-GetYRotation(), transform.localEulerAngles.y, 0);
                    break;
            }
        }

        float GetXRotation()
        {
            rotationX += Input.GetAxis("Mouse X") * sensitivityX.value;
            rotationX = ClampAngle(rotationX, minimumX.value, maximumX.value);
            return rotationX;
        }

        float GetYRotation()
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY.value;
            rotationY = ClampAngle(rotationY, minimumY.value, maximumY.value);
            return rotationY;
        }

        // Clamp function that respects IsNone
        static float ClampAngle(float angle, float min, float max)
        {
            if (angle < min)
            {
                angle = min;
            }
            if (angle > max)
            {
                angle = max;
            }
            return angle;
        }
    }
}