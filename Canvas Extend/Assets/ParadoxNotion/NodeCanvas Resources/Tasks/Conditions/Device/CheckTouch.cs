using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions
{

    [Category("Device")]
    public class CheckTouch : ConditionTask
    {
        public BBParameter<int> fingerId;
        public BBParameter<TouchPhase> touchPhase;
        [BlackboardOnly]
        public BBParameter<int> storeFingerId;
        protected override string info
        {
            get { return string.Format("fingerId {0} touch {1}", fingerId.ToString(), touchPhase.ToString()); }
        }

        protected override bool OnCheck()
        {
            if (Input.touchCount > 0)
            {
                foreach (var touch in Input.touches)
                {
                    if (touch.fingerId == fingerId.value)
                    {
                        if (touch.phase == touchPhase.value)
                        {
                            storeFingerId.value = touch.fingerId;
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}