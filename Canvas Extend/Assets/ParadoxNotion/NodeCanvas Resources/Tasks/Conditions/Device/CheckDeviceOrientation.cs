using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions{

	[Category("Device")]
	public class CheckDeviceOrientation : ConditionTask{

		public BBParameter<DeviceOrientation> value;

		protected override string info{
			get{return "Input.deviceOrientation  == " + value;}
		}

		protected override bool OnCheck(){
			return Input.deviceOrientation == value.value;
		}
	}
}