using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions{

	[Category("Input")]
	public class CheckScreenPick : ConditionTask{

        public BBParameter<Vector3> screenVector;
        public BBParameter<bool> normalized;
        public BBParameter<float> rayDistance = 100f;
        public BBParameter<LayerMask> layerMask;
        public BBParameter<bool> invertMask;
        [BlackboardOnly]
        public BBParameter<GameObject> storeGameObject;
        [BlackboardOnly]
        public BBParameter<Vector3> storePoint;
        [BlackboardOnly]
        public BBParameter<Vector3> storeNormal;
        [BlackboardOnly]
        public BBParameter<float> storeDistance;

        private RaycastHit hit;

		protected override string info{
			get
			{
				var finalString= " ScreenPick";
				if (!string.IsNullOrEmpty(storePoint.name))
					finalString += string.Format("\n<i>(SavePos As {0})</i>", storePoint);
				if (!string.IsNullOrEmpty(storeGameObject.name))
					finalString += string.Format("\n<i>(SaveGo As {0})</i>", storeGameObject);
				return finalString;
			}
		}

		protected override bool OnCheck(){

            if (Camera.main == null)
            {
                return false;
            }
            int mask = layerMask.value;
            if (invertMask.value)
            {
                mask = ~mask;
            }
            var rayStart = Vector3.zero;
            rayStart = screenVector.value;

            if (normalized.value)
            {
                rayStart.x *= Screen.width;
                rayStart.y *= Screen.height;
            }

            if (Physics.Raycast(Camera.main.ScreenPointToRay(rayStart), out hit, rayDistance.value, mask))
            {
                storePoint.value = hit.point;
                storeGameObject.value = hit.collider.gameObject;
                storeDistance.value = hit.distance;
                storeNormal.value = hit.normal;
                return true;
            }
            return false;
		}
	}
}