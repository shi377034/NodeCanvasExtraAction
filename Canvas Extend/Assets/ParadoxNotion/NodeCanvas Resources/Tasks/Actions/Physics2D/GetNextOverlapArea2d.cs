using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{

	[Category("Physics2D")]
	public class GetNextOverlapArea2d : ActionTask
    {
        public BBParameter<GameObject> firstCornerGameObject;
        public BBParameter<Vector2> firstCornerPosition;
        public BBParameter<GameObject> secondCornerGameObject;
        public BBParameter<Vector2> secondCornerPosition;
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
        // increment a child index as we loop through children
        private int nextColliderIndex;
        protected override void OnExecute(){
            if (colliders == null || resetFlag.value)
            {
                nextColliderIndex = 0;
                colliders = GetOverlapAreaAll();
                colliderCount = colliders.Length;
                collidersCount.value = colliderCount;
                resetFlag.value = false;
            }
            if (nextColliderIndex >= colliderCount)
            {
                nextColliderIndex = 0;
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
        private Collider2D[] GetOverlapAreaAll()
        {
            var firstGo = firstCornerGameObject.value;

            var firstCornerPos = firstCornerPosition.value;

            if (firstGo != null)
            {
                firstCornerPos.x += firstGo.transform.position.x;
                firstCornerPos.y += firstGo.transform.position.y;
            }

            var secondGo = secondCornerGameObject.value;

            var secondCornerPos = secondCornerPosition.value;

            if (secondGo != null)
            {
                secondCornerPos.x += secondGo.transform.position.x;
                secondCornerPos.y += secondGo.transform.position.y;
            }

            var _minDepth = minDepth.value;
            var _maxDepth = maxDepth.value;
            int layer = layerMask.value;
            if (invertMask.value)
            {
                layer = ~layer;
            }
            return Physics2D.OverlapAreaAll(firstCornerPos, secondCornerPos, layer, _minDepth, _maxDepth);
        }
    }
}