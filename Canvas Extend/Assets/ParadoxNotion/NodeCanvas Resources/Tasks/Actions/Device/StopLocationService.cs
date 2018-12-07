using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;
namespace NodeCanvas.Tasks.Actions{
	[Category("Device")]
	public class StopLocationService : ActionTask
    {
        protected override void OnExecute(){
#if UNITY_IPHONE || UNITY_IOS || UNITY_ANDROID || UNITY_BLACKBERRY || UNITY_WP8
  			Input.location.Stop();
#endif
            EndAction();
        }
    }
}