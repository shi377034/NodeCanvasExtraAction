using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;
namespace NodeCanvas.Tasks.Actions{
	[Category("Device")]
	public class GetDeviceAcceleration : ActionTask
    {
        [BlackboardOnly]
        public BBParameter<Vector3> storeVector;
        [BlackboardOnly]
        public BBParameter<float> storeX;
        [BlackboardOnly]
        public BBParameter<float> storeY;
        [BlackboardOnly]
        public BBParameter<float> storeZ;
        public BBParameter<float> multiplier = 1f;
        protected override void OnExecute(){
            var dir = new Vector3(Input.acceleration.x, Input.acceleration.y, Input.acceleration.z);

            dir *= multiplier.value;

            storeVector.value = dir;
            storeX.value = dir.x;
            storeY.value = dir.y;
            storeZ.value = dir.z;
            EndAction();
        }
    }
}