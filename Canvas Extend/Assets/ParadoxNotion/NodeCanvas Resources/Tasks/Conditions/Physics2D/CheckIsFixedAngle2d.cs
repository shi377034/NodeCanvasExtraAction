using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions{
	[Category("Physics")]
	public class CheckIsFixedAngle2d : ConditionTask<Rigidbody2D>
    {
        public BBParameter<bool> value;
        protected override string info
        {
            get { return "Rigidbody2D.IsFixedAngle == " + value; }
        }
        protected override bool OnCheck()
        {
            bool isfixedAngle = false;

#if UNITY_5_3_5 || UNITY_5_4_OR_NEWER
            isfixedAngle = (agent.constraints & RigidbodyConstraints2D.FreezeRotation) != 0;
#else
			isfixedAngle = agent.fixedAngle;
#endif
            return isfixedAngle == value.value;
        }
    } 
}