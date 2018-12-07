using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{

	[Category("Physics2D")]
	public class GetNextOverlapCircle2d : ActionTask
    {
        public BBParameter<GameObject> fromGameObject;
        public BBParameter<Vector2> fromPosition;
        public BBParameter<float> radius;
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

        private Collider2D[] colliders;

        private int colliderCount;

        // increment an index as we loop through children
        private int nextColliderIndex;
        protected override void OnExecute(){
            if (colliders == null || resetFlag.value)
            {
                nextColliderIndex = 0;
                colliders = GetOverlapCircleAll();
                colliderCount = colliders.Length;
                collidersCount.value = colliderCount;
                resetFlag.value = false;
            }
            if (nextColliderIndex >= colliderCount)
            {
                nextColliderIndex = 0;
                colliders = null;
                this.SendEvent(finishedEvent.value);
                EndAction();
                return;
            }

            // get next collider

            storeNextCollider.value = colliders[nextColliderIndex].gameObject;


            // no more colliders?
            // check a second time to avoid process lock and possible infinite loop if the action is called again.
            // Practically, this enabled calling again this state and it will start again iterating from the first child.

            if (nextColliderIndex >= colliderCount)
            {
                colliders = null;
                nextColliderIndex = 0;
                this.SendEvent(finishedEvent.value);
                EndAction();
                return;
            }

            // iterate the next collider
            nextColliderIndex++;
            EndAction();
		}
        private Collider2D[] GetOverlapCircleAll()
        {
            var fromGo = fromGameObject.value;

            var fromPos = fromPosition.value;

            if (fromGo != null)
            {
                fromPos.x += fromGo.transform.position.x;
                fromPos.y += fromGo.transform.position.y;
            }

            var _minDepth = minDepth.value;
            var _maxDepth = maxDepth.value;
            int layer = layerMask.value;
            if (invertMask.value)
            {
                layer = ~layer;
            }
            return Physics2D.OverlapCircleAll(fromPos, radius.value, layer, _minDepth, _maxDepth);
        }
    }
}