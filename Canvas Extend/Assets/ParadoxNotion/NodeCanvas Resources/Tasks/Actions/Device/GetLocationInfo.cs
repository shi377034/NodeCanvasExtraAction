using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;
namespace NodeCanvas.Tasks.Actions{
	[Category("Device")]
	public class GetLocationInfo : ActionTask
    {
        [BlackboardOnly]
        public BBParameter<Vector3> vectorPosition;
        [BlackboardOnly]
        public BBParameter<float> longitude;
        [BlackboardOnly]
        public BBParameter<float> latitude;
        [BlackboardOnly]
        public BBParameter<float> altitude;
        [BlackboardOnly]
        public BBParameter<float> horizontalAccuracy;
        [BlackboardOnly]
        public BBParameter<float> verticalAccuracy;
        protected override void OnExecute(){
#if UNITY_IPHONE || UNITY_IOS || UNITY_ANDROID || UNITY_BLACKBERRY || UNITY_WP8

			if (Input.location.status != LocationServiceStatus.Running)
			{
                EndAction();
				return;
			}
			
			float x = Input.location.lastData.longitude;
			float y = Input.location.lastData.latitude;
			float z = Input.location.lastData.altitude;
			
			vectorPosition.value = new Vector3(x,y,z);
			
			longitude.value = x;
			latitude.value = y;
			altitude.value = z;

			horizontalAccuracy.value = Input.location.lastData.horizontalAccuracy;
			verticalAccuracy.value = Input.location.lastData.verticalAccuracy;
			
#endif
            EndAction();
        }
    }
}