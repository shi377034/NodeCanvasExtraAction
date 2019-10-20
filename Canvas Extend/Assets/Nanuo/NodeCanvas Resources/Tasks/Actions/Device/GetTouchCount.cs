using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;
namespace NodeCanvas.Tasks.Actions{
	[Category("Device")]
	public class GetTouchCount : ActionTask
    {
        [BlackboardOnly]
        public BBParameter<int> storeCount;
        protected override void OnExecute(){
            storeCount.value = Input.touchCount;
            EndAction();
        }
    }
}