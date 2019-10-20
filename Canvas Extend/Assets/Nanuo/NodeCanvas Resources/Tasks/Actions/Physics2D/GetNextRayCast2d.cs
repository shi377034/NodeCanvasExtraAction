using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{

	[Category("Physics2D")]
	public class GetNextRayCast2d : ActionTask
    {
        public BBParameter<GameObject> fromGameObject;
        public BBParameter<Vector2> fromPosition;
        public BBParameter<Vector2> direction;
        public Space space = Space.Self;
        public BBParameter<float> distance;
        public BBParameter<int> minDepth;
        public BBParameter<int> maxDepth;
        public BBParameter<bool> resetFlag;
        public BBParameter<LayerMask> layerMask;
        public BBParameter<bool> invertMask;
        public BBParameter<string> finishedEvent;
        [BlackboardOnly]
        public BBParameter<int> collidersCount;
        [BlackboardOnly]
        public BBParameter<GameObject> storeNextCollider;
        [BlackboardOnly]
        public BBParameter<Vector2> storeNextHitPoint;
        [BlackboardOnly]
        public BBParameter<Vector2> storeNextHitNormal;
        [BlackboardOnly]
        public BBParameter<float> storeNextHitDistance;
        [BlackboardOnly]
        public BBParameter<float> storeNextHitFraction;

        private RaycastHit2D[] hits;

        private int colliderCount;

        // increment an index as we loop through children
        private int nextColliderIndex;

        protected override void OnExecute(){
            if (hits == null || resetFlag.value)
            {
                nextColliderIndex = 0;
                hits = GetRayCastAll();
                colliderCount = hits.Length;
                collidersCount.value = colliderCount;
                resetFlag.value = false;
            }
            if (nextColliderIndex >= colliderCount)
            {
                hits = null;
                nextColliderIndex = 0;
                this.SendEvent(finishedEvent.value);
                EndAction();
                return;
            }

            // get next collider
            storeNextCollider.value = hits[nextColliderIndex].collider.gameObject;
            storeNextHitPoint.value = hits[nextColliderIndex].point;
            storeNextHitNormal.value = hits[nextColliderIndex].normal;
            storeNextHitDistance.value = hits[nextColliderIndex].distance;
            storeNextHitFraction.value = hits[nextColliderIndex].fraction;

            // no more colliders?
            // check a second time to avoid process lock and possible infinite loop if the action is called again.
            // Practically, this enabled calling again this state and it will start again iterating from the first child.

            if (nextColliderIndex >= colliderCount)
            {
                hits = new RaycastHit2D[0];
                nextColliderIndex = 0;
                this.SendEvent(finishedEvent.value);
                EndAction();
                return;
            }

            // iterate the next collider
            nextColliderIndex++;
            EndAction();
		}
        private RaycastHit2D[] GetRayCastAll()
        {
            if (Mathf.Abs(distance.value) < Mathf.Epsilon)
            {
                return new RaycastHit2D[0];
            }

            var go = fromGameObject.value;

            var originPos = fromPosition.value;

            if (go != null)
            {
                originPos.x += go.transform.position.x;
                originPos.y += go.transform.position.y;
            }

            var rayLength = Mathf.Infinity;
            if (distance.value > 0)
            {
                rayLength = distance.value;
            }

            var dirVector2 = direction.value.normalized; // normalized to get the proper distance later using fraction from the rayCastHitinfo.

            if (go != null && space == Space.Self)
            {

                var dirVector = go.transform.TransformDirection(new Vector3(direction.value.x, direction.value.y, 0f));
                dirVector2.x = dirVector.x;
                dirVector2.y = dirVector.y;
            }

            var _minDepth = minDepth.value;
            var _maxDepth = maxDepth.value;
            int layer = layerMask.value;
            if (invertMask.value)
            {
                layer = ~layer;
            }
            return Physics2D.RaycastAll(originPos, dirVector2, rayLength, layer, _minDepth, _maxDepth);
        }
    }
}