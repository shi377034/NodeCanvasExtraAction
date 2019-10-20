using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace NodeCanvas.Tasks.Conditions{

	[Category("UGUI")]
	public class SliderOnValueChanged : ConditionTask<Slider>
    {
        [BlackboardOnly]
        public BBParameter<float> value;
        protected override string OnInit()
        {
            agent.onValueChanged.AddListener(DoOnValueChange);
            return null;
        }
        protected override bool OnCheck()
        { 
            return false;
        }
        void DoOnValueChange(float value)
        {
            this.value.value = value;
            YieldReturn(true);
        }
    }
}