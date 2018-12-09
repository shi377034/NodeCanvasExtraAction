using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace NodeCanvas.Tasks.Conditions{

	[Category("UGUI")]
	public class ScrollbarOnValueChanged : ConditionTask<Scrollbar>
    {
        [BlackboardOnly]
        public BBParameter<float> value;
        protected override string OnInit()
        {
            agent.onValueChanged.AddListener(OnValueChanged);
            return null;
        }
        protected override bool OnCheck()
        { 
            return false;
        }
        void OnValueChanged(float value)
        {
            this.value.value = value;
            YieldReturn(true);
        }
    }
}