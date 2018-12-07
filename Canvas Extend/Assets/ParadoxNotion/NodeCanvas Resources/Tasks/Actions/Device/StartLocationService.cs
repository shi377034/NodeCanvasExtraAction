using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;
namespace NodeCanvas.Tasks.Actions{
	[Category("Device")]
	public class StartLocationService : ActionTask
    {
        public BBParameter<float> desiredAccuracy = 10f;
        public BBParameter<float> updateDistance = 10f;
        protected override void OnExecute(){
#if UNITY_IPHONE || UNITY_IOS || UNITY_ANDROID || UNITY_BLACKBERRY || UNITY_WP8
  			Input.location.Start(desiredAccuracy.value, updateDistance.value);      
#endif
            EndAction();
        }
    }
}