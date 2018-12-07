using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions{
	[Category("Camera")]
	public class WorldToScreenPoint : ActionTask<Camera>
    {
        public BBParameter<Vector3> worldPosition;
        [BlackboardOnly]
        public BBParameter<Vector3> storeScreenPoint;
        [BlackboardOnly]
        public BBParameter<float> storeScreenX;
        [BlackboardOnly]
        public BBParameter<float> storeScreenY;
        public BBParameter<bool> normalize;
        protected override void OnExecute(){
            var position = Vector3.zero;

            position = worldPosition.value;

            position = agent.WorldToScreenPoint(position);

            if (normalize.value)
            {
                position.x /= Screen.width;
                position.y /= Screen.height;
            }

            storeScreenPoint.value = position;
            storeScreenX.value = position.x;
            storeScreenY.value = position.y;
            EndAction();
        }
    }
}