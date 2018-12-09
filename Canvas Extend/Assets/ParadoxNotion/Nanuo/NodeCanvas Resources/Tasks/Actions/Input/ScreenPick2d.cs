using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{

	[Category("Input")]
	public class ScreenPick2d : ActionTask
    {
        public BBParameter<Vector2> screenVector;
        public BBParameter<bool> normalized;
        public BBParameter<LayerMask> layerMask;
        public BBParameter<bool> invertMask;
        [BlackboardOnly]
        public BBParameter<bool> storeDidPickObject;
        [BlackboardOnly]
        public BBParameter<GameObject> storeGameObject;
        [BlackboardOnly]
        public BBParameter<Vector3> storePoint;

        protected override void OnExecute(){
            if (Camera.main == null)
            {
                Debug.LogError("No MainCamera defined!");
                EndAction(false);
                return;
            }
            EndAction();
		}
        void DoScreenPick()
        {


            var rayStart = Vector3.zero;

            rayStart = screenVector.value;

            if (normalized.value)
            {
                rayStart.x *= Screen.width;
                rayStart.y *= Screen.height;
            }
            int layer = layerMask.value;
            if (invertMask.value)
            {
                layer = ~layer;
            }
            var hitInfo = Physics2D.GetRayIntersection(
                Camera.main.ScreenPointToRay(rayStart),
                Mathf.Infinity,
                layer);

            var didPick = hitInfo.collider != null;
            storeDidPickObject.value = didPick;

            if (didPick)
            {
                storeGameObject.value = hitInfo.collider.gameObject;
                storePoint.value = hitInfo.point;
            }
            else
            {
                // TODO: not sure if this is the right strategy...
                storeGameObject.value = null;
                storePoint.value = Vector3.zero;
            }

        }
    }
}