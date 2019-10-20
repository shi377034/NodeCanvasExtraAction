using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions{

	[Category("Input")]
	public class WaitScreenPick : ActionTask {

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
			get {return string.Format("Wait Object Screen Pick. Save As {0}",storeGameObject);}
		}

		protected override void OnUpdate(){
            if (Camera.main == null)
            {
                EndAction();
                return;
            }
                int mask = layerMask.value;
            if(invertMask.value)
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
                EndAction(true);
            }
        }
	}
}