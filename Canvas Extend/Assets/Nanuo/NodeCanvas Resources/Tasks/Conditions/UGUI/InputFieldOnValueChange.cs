using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace NodeCanvas.Tasks.Conditions{

	[Category("UGUI")]
	public class InputFieldOnValueChange : ConditionTask<InputField>
    {
        [BlackboardOnly]
        public BBParameter<string> text;
        protected override string OnInit()
        {
            agent.onValueChanged.AddListener(DoOnValueChange);
            return null;
        }
        protected override bool OnCheck()
        { 
            return false;
        }
        void DoOnValueChange(string value)
        {
            text.value = value;
            YieldReturn(true);
        }
    }
}