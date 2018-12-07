using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;
namespace NodeCanvas.Tasks.Actions{
	[Category("Device")]
    [Description("Causes the device to vibrate for half a second.")]
	public class DeviceVibrate : ActionTask
    {
        protected override void OnExecute(){
#if (UNITY_IPHONE || UNITY_IOS || UNITY_ANDROID)
			Handheld.Vibrate();
#endif
            EndAction();
        }
    }
}