using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{

	[Category("Physics2D")]
	public class LineCast2d : ActionTask<Rigidbody2D>
    {
        public BBParameter<GameObject> fromGameObject;
        public BBParameter<Vector2> fromPosition;
        public BBParameter<GameObject> toGameObject;
        public BBParameter<Vector2> toPosition;
        public BBParameter<int> minDepth;
        public BBParameter<int> maxDepth;
        public BBParameter<LayerMask> layerMask;
        public BBParameter<bool> invertMask;
        public BBParameter<string> hitEvent;
        [BlackboardOnly]
        public BBParameter<bool> storeDidHit;
        [BlackboardOnly]
        public BBParameter<GameObject> storeHitObject;
        [BlackboardOnly]
        public BBParameter<Vector2> storeHitPoint;
        [BlackboardOnly]
        public BBParameter<Vector2> storeHitNormal;
        [BlackboardOnly]
        public BBParameter<float> storeHitDistance;
        [BlackboardOnly]
        public BBParameter<float> storeHitFraction;
        public BBParameter<Color> debugColor = Color.yellow;
        public BBParameter<bool> debug;
        private Transform _fromTrans;
        private Transform _toTrans;
        protected override void OnExecute(){
            var fromGo = fromGameObject.value;
            if (fromGo != null)
            {
                _fromTrans = fromGo.transform;
            }

            var toGo = toGameObject.value;
            if (toGo != null)
            {
                _toTrans = toGo.transform;
            }
            DoRaycast();
            EndAction();
		}
        private void DoRaycast()
        {
            var fromPos = fromPosition.value;

            if (_fromTrans != null)
            {
                fromPos.x += _fromTrans.position.x;
                fromPos.y += _fromTrans.position.y;
            }

            var toPos = toPosition.value;

            if (_toTrans != null)
            {
                toPos.x += _toTrans.position.x;
                toPos.y += _toTrans.position.y;
            }


            RaycastHit2D hitInfo;

            var _minDepth = minDepth.value;
            var _maxDepth = maxDepth.value;
            int layer = layerMask.value;
            if (invertMask.value)
            {
                layer = ~layer;
            }
            hitInfo = Physics2D.Linecast(fromPos, toPos, layer, _minDepth, _maxDepth);

            var didHit = hitInfo.collider != null;

            storeDidHit.value = didHit;

            if (didHit)
            {
                storeHitObject.value = hitInfo.collider.gameObject;
                storeHitPoint.value = hitInfo.point;
                storeHitNormal.value = hitInfo.normal;
                storeHitDistance.value = hitInfo.distance;
                storeHitFraction.value = hitInfo.fraction;
                this.SendEvent(hitEvent.value);
            }

            if (debug.value)
            {
                var start = new Vector3(fromPos.x, fromPos.y, 0);
                var end = new Vector3(toPos.x, toPos.y, 0);

                Debug.DrawLine(start, end, debugColor.value);
            }
        }
    }
}