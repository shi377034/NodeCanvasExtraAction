using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions{
	[Category("Physics")]
	public class CheckIsKinematic2d : ConditionTask<Rigidbody2D>
    {
        public BBParameter<bool> value;
        protected override string info
        {
            get { return "Rigidbody2D.IsKinematic == " + value; }
        }
        protected override bool OnCheck()
        {
            return agent.isKinematic == value.value;
        }
    } 
}