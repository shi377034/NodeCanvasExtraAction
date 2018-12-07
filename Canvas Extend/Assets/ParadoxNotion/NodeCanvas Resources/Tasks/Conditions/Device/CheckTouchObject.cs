using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions
{
    [Category("Device")]
    public class CheckTouchObject : ConditionTask<Collider>
    {
        public BBParameter<float> pickDistance = 100F;
        public BBParameter<int> fingerId;
        public BBParameter<TouchPhase> touchPhase;
        [BlackboardOnly]
        public BBParameter<int> storeFingerId;
        [BlackboardOnly]
        public BBParameter<Vector3> storeHitPoint;
        [BlackboardOnly]
        public BBParameter<Vector3> storeHitNormal;
        protected override string info
        {
            get { return "touch " + agent.ToString(); }
        }

        protected override bool OnCheck()
        {
            if(Camera.main != null)
            {
                if (Input.touchCount > 0)
                {
                    foreach (var touch in Input.touches)
                    {
                        if (touch.fingerId == fingerId.value)
                        {
                            var screenPos = touch.position;

                            RaycastHit hitInfo;
                            Physics.Raycast(Camera.main.ScreenPointToRay(screenPos), out hitInfo, pickDistance.value);

                            if (hitInfo.transform != null)
                            {
                                if (hitInfo.transform.gameObject == agent)
                                {
                                    storeFingerId.value = touch.fingerId;
                                    storeHitPoint.value = hitInfo.point;
                                    storeHitNormal.value = hitInfo.normal;
                                    if(touch.phase == touchPhase.value)
                                    {
                                        return true;
                                    }                                  
                                }
                            }
                        }
                    }
                }
            }      
            return false;
        }
    }
}