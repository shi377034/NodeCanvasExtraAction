using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace NodeCanvas.Tasks.Conditions{

	[Category("UGUI")]
	public class DropDownOnValueChanged : ConditionTask<Dropdown>
    {
        [BlackboardOnly]
        public BBParameter<int> index;
        [BlackboardOnly]
        public BBParameter<string> text;
        [BlackboardOnly]
        public BBParameter<Sprite> image;

        protected override string OnInit()
        {
            agent.onValueChanged.AddListener(OnValueChanged);
            return null;
        }
        protected override bool OnCheck()
        { 
            return false;
        }
        void OnValueChanged(int index)
        {
            this.index.value = index;
            text.value = agent.options[index].text;
            image.value = agent.options[index].image;
            YieldReturn(true);
        }
    }
}