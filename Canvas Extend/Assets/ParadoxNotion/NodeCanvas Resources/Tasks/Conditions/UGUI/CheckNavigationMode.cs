using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace NodeCanvas.Tasks.Conditions{

	[Category("UGUI")]
	public class CheckNavigationMode : ConditionTask<Selectable>
    {
        public BBParameter<Navigation.Mode> value;
        protected override string info
        {
            get { return string.Format("navigation.mode == {0}", value); }
        }

        protected override bool OnCheck()
        { 
            return agent.navigation.mode == value.value;
        }
    }
}