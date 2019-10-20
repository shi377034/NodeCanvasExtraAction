using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions{
	[Category("Physics")]
	public class CheckRaycast : ConditionTask{
        public BBParameter<Vector3> origin;
        public BBParameter<Vector3> direction;
        public BBParameter<float> maxDistance;
        public BBParameter<LayerMask> layerMask;
        public QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal;
        [BlackboardOnly]
        public BBParameter<GameObject> Hit;
        [BlackboardOnly]
        public BBParameter<Vector3> point;
        [BlackboardOnly]
        public BBParameter<Vector3> normal;
        [BlackboardOnly]
        public BBParameter<float> distance;

        private RaycastHit raycastHit;
        protected override bool OnCheck()
        {
            if (Physics.Raycast(origin.value, direction.value, out raycastHit, maxDistance.value, layerMask.value, queryTriggerInteraction))
            {
                Hit.value = raycastHit.collider.gameObject;
                point.value = raycastHit.point;
                normal.value = raycastHit.normal;
                distance.value = raycastHit.distance;
                return true;
            }
            return false;
        }
    } 
}