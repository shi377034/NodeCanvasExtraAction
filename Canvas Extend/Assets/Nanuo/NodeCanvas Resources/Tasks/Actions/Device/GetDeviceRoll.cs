using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;
namespace NodeCanvas.Tasks.Actions{
	[Category("Device")]
    [Description("Gets the rotation of the device around its z axis (into the screen). For example when you steer with the iPhone in a driving game.")]
	public class GetDeviceRoll : ActionTask
    {
        public enum BaseOrientation
        {
            Portrait,
            LandscapeLeft,
            LandscapeRight
        }
        public BBParameter<BaseOrientation> baseOrientation;
        public BBParameter<float> storeAngle;
        public BBParameter<float> limitAngle;
        public BBParameter<float> smoothing = 5f;
        private float lastZAngle;
        protected override void OnExecute(){
            float x = Input.acceleration.x;
            float y = Input.acceleration.y;
            float zAngle = 0;

            switch (baseOrientation.value)
            {
                case BaseOrientation.Portrait:
                    zAngle = -Mathf.Atan2(x, -y);
                    break;
                case BaseOrientation.LandscapeLeft:
                    zAngle = Mathf.Atan2(y, -x);
                    break;
                case BaseOrientation.LandscapeRight:
                    zAngle = -Mathf.Atan2(y, x);
                    break;
            }

            zAngle = Mathf.Clamp(Mathf.Rad2Deg * zAngle, -limitAngle.value, limitAngle.value);

            zAngle = Mathf.LerpAngle(lastZAngle, zAngle, smoothing.value * Time.deltaTime);

            lastZAngle = zAngle;

            storeAngle.value = zAngle;
            EndAction();
        }
    }
}