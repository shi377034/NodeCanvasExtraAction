using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{

	[Category("Physics2D")]
	public class GetNextLineCast2d : ActionTask<Rigidbody2D>
    {
        public BBParameter<GameObject> fromGameObject;
        public BBParameter<GameObject> toGameObject;
        public BBParameter<Vector2> fromPosition;
        public BBParameter<Vector2> toPosition;
        public BBParameter<LayerMask> layerMask;
        public BBParameter<bool> invertMask;
        public BBParameter<float> minDepth;
        public BBParameter<float> maxDepth;
        public BBParameter<bool> resetFlag;
        public BBParameter<string> finishedEvent;
        [BlackboardOnly]
        public BBParameter<int> collidersCount;
        [BlackboardOnly]
        public BBParameter<GameObject> storeNextCollider;
        [BlackboardOnly]
        public BBParameter<Vector2> storeNextHitCentroid;
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
                hits = GetLineCastAll();
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
        private RaycastHit2D[] GetLineCastAll()
        {
            var fromPos = fromPosition.value;
            if (fromGameObject.value != null)
            {
                fromPos.x += fromGameObject.value.transform.position.x;
                fromPos.y += fromGameObject.value.transform.position.y;
            }

            var toPos = toPosition.value;

            var toGo = toGameObject.value;

            if (toGo != null)
            {
                toPos.x += toGo.transform.position.x;
                toPos.y += toGo.transform.position.y;
            }


            var _minDepth = minDepth.value;
            var _maxDepth = maxDepth.value;
            int layer = layerMask.value;
            if (invertMask.value)
            {
                layer = ~layer;
            }
            return Physics2D.LinecastAll(fromPos, toPos, layer, _minDepth, _maxDepth);
        }
    }
}