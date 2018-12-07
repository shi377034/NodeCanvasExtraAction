using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions{
	[Category("Physics")]
	public class CheckIsSleeping2d : ConditionTask<Rigidbody2D>
    {
        public BBParameter<bool> value;
        protected override string info
        {
            get { return "Rigidbody2D.IsSleeping == " + value; }
        }
        protected override bool OnCheck()
        {
            return agent.IsSleeping() == value.value;
        }
    } 
}