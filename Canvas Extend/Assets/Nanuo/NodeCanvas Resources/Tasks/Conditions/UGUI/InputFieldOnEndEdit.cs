using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace NodeCanvas.Tasks.Conditions{

	[Category("UGUI")]
	public class InputFieldOnEndEdit : ConditionTask<InputField>
    {
        [BlackboardOnly]
        public BBParameter<string> text;
        [BlackboardOnly]
        public BBParameter<bool> wasCanceled;
        protected override string OnInit()
        {
            agent.onEndEdit.AddListener(DoOnEndEdit);
            return null;
        }
        protected override bool OnCheck()
        { 
            return false;
        }
        void DoOnEndEdit(string value)
        {
            text.value = value;
            wasCanceled.value = agent.wasCanceled;
            YieldReturn(true);
        }
    }
}