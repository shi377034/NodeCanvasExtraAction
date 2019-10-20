using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions{
	[Category("Physics")]
	public class CheckRaycast2D : ConditionTask{
        public BBParameter<Vector2> origin;
        public BBParameter<Vector2> direction;
        public BBParameter<float> maxDistance;
        public BBParameter<LayerMask> layerMask;
        public BBParameter<float> minDepth;
        public BBParameter<float> maxDepth;
        [BlackboardOnly]
        public BBParameter<GameObject> Hit;
        [BlackboardOnly]
        public BBParameter<Vector2> centroid;
        [BlackboardOnly]
        public BBParameter<Vector2> point;
        [BlackboardOnly]
        public BBParameter<Vector2> normal;
        [BlackboardOnly]
        public BBParameter<float> distance;
        [BlackboardOnly]
        public BBParameter<float> fraction;
        private RaycastHit2D raycastHit2D;
        protected override bool OnCheck()
        {
            raycastHit2D = Physics2D.Raycast(origin.value, direction.value, maxDistance.value, layerMask.value, minDepth.value, maxDepth.value);
            if (raycastHit2D.collider != null)
            {
                Hit.value = raycastHit2D.collider.gameObject;
                centroid.value = raycastHit2D.centroid;
                point.value = raycastHit2D.point;
                normal.value = raycastHit2D.normal;
                distance.value = raycastHit2D.distance;
                fraction.value = raycastHit2D.fraction;
                return true;
            }
            return false;
        }
    } 
}