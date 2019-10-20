using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions{

	[Category("Device")]
	public class CheckLocationStatus : ConditionTask{

        public BBParameter<LocationServiceStatus> value;

        protected override string info
        {
            get { return "Location Status == " + value; }
        }

        protected override bool OnCheck(){
            return Input.location.status == value.value;
		}
	}
}