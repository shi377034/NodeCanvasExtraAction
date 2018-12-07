using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.UI;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{

    [Category("UGUI")]
    public class ToggleOnValueChanged : ConditionTask
    {
        [RequiredField]
        public BBParameter<Toggle> toggle;
        public BBParameter<bool> value;

        protected override string info
        {
            get { return string.Format("Toggle {0} Value Changed {1}", toggle.ToString(), value); }
        }

        protected override string OnInit()
        {
            toggle.value.onValueChanged.AddListener(OnClick);
            return null;
        }

        protected override bool OnCheck() { return false; }
        void OnClick(bool value)
        {
            this.value.value = value;
            YieldReturn(true);
        }
    }
}