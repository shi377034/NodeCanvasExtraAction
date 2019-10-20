using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;
namespace NodeCanvas.Tasks.Actions{
	[Category("Device")]
	public class GetIPhoneSettings : ActionTask
    {
        [BlackboardOnly]
        [Tooltip("Allows device to fall into 'sleep' state with screen being dim if no touches occurred. Default value is true.")]
        public BBParameter<bool> getScreenCanDarken;
        [BlackboardOnly]
        [Tooltip("A unique device identifier string. It is guaranteed to be unique for every device (Read Only).")]
        public BBParameter<string> getUniqueIdentifier;
        [BlackboardOnly]
        [Tooltip("The user defined name of the device (Read Only).")]
        public BBParameter<string> getName;
        [BlackboardOnly]
        [Tooltip("The model of the device (Read Only).")]
        public BBParameter<string> getModel;
        [BlackboardOnly]
        [Tooltip("The name of the operating system running on the device (Read Only).")]
        public BBParameter<string> getSystemName;
        [BlackboardOnly]
        [Tooltip("The generation of the device (Read Only).")]
        public BBParameter<string> getGeneration;
        protected override void OnExecute(){
#if UNITY_IPHONE || UNITY_IOS
			
			getScreenCanDarken.value = Screen.sleepTimeout > 0f; //iPhoneSettings.screenCanDarken;
			getUniqueIdentifier.value = SystemInfo.deviceUniqueIdentifier; //iPhoneSettings.uniqueIdentifier;
			getName.value = SystemInfo.deviceName; //iPhoneSettings.name;
			getModel.value = SystemInfo.deviceModel; //iPhoneSettings.model;
			getSystemName.value = SystemInfo.operatingSystem; //iPhoneSettings.systemName;
#if UNITY_4_3 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7
            getGeneration.value = iPhone.generation.ToString();
#else
            getGeneration.value = UnityEngine.iOS.Device.generation.ToString();
#endif
#endif
            EndAction();
        }
    }
}