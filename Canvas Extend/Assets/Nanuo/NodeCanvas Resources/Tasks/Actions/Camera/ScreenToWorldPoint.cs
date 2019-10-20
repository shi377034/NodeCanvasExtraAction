using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions{
	[Category("Camera")]
	public class ScreenToWorldPoint : ActionTask<Camera>
    {
        public BBParameter<Vector3> screenVector;
        public BBParameter<bool> normalized;
        [BlackboardOnly]
        public BBParameter<Vector3> storeWorldVector;
        [BlackboardOnly]
        public BBParameter<float> storeWorldX;
        [BlackboardOnly]
        public BBParameter<float> storeWorldY;
        [BlackboardOnly]
        public BBParameter<float> storeWorldZ;
        protected override void OnExecute(){
            var position = Vector3.zero;

            position = screenVector.value;

            if (normalized.value)
            {
                position.x *= Screen.width;
                position.y *= Screen.height;
            }

            position = agent.ScreenToWorldPoint(position);

            storeWorldVector.value = position;
            storeWorldX.value = position.x;
            storeWorldY.value = position.y;
            storeWorldZ.value = position.z;
            EndAction();
        }
    }
}