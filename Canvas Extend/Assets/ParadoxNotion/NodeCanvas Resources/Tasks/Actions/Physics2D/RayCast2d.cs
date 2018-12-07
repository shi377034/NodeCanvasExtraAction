using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{

	[Category("Physics2D")]
	public class RayCast2d : ActionTask
    {
        public BBParameter<GameObject> fromGameObject;
        public BBParameter<Vector2> fromPosition;
        public BBParameter<Vector2> direction;
        public Space space = Space.Self;
        public BBParameter<float> distance = 100f;
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
        public BBParameter<bool> debug;
        public BBParameter<Color> debugLineColor = Color.yellow;
        private Transform _transform;
        protected override void OnExecute(){
            var go = fromGameObject.value;
            if (go != null)
            {
                _transform = go.transform;
            }
            EndAction();
		}
        private void DoRaycast()
        {
            if (Mathf.Abs(distance.value) < Mathf.Epsilon)
            {
                return;
            }

            var originPos = fromPosition.value;

            if (_transform != null)
            {
                originPos.x += _transform.position.x;
                originPos.y += _transform.position.y;
            }

            var rayLength = Mathf.Infinity;
            if (distance.value > 0)
            {
                rayLength = distance.value;
            }

            var dirVector2 = direction.value.normalized; // normalized to get the proper distance later using fraction from the rayCastHitinfo.

            if (_transform != null && space == Space.Self)
            {

                var dirVector = _transform.TransformDirection(new Vector3(direction.value.x, direction.value.y, 0f));
                dirVector2.x = dirVector.x;
                dirVector2.y = dirVector.y;
            }

            RaycastHit2D hitInfo;

            var _minDepth =  minDepth.value;
            var _maxDepth = maxDepth.value;
            int layer = layerMask.value;
            if (invertMask.value)
            {
                layer = ~layer;
            }
            hitInfo = Physics2D.Raycast(originPos, dirVector2, rayLength, layer, _minDepth, _maxDepth);

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
                var debugRayLength = Mathf.Min(rayLength, 1000);
                var start = new Vector3(originPos.x, originPos.y, 0);
                var dirVector3 = new Vector3(dirVector2.x, dirVector2.y, 0);
                var end = start + dirVector3 * debugRayLength;

                Debug.DrawLine(start, end, debugLineColor.value);
            }
        }
    }
}