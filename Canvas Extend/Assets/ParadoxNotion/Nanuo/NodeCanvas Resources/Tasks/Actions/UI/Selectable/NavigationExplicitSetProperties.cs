using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Set Navigation Properties")]
    [Category("UI/Selectable")]
    public class NavigationExplicitSetProperties : ActionTask<Selectable>
    {
        public BBParameter<Selectable> selectOnDown;
        public BBParameter<Selectable> selectOnUp;
        public BBParameter<Selectable> selectOnLeft;
        public BBParameter<Selectable> selectOnRight;
        private Selectable selectable;
        private Navigation navigation;
        protected override void OnExecute()
        {
            selectable = agent;
            DoSetValue();
            EndAction();
        }
        private void DoSetValue()
        {
            navigation = selectable.navigation;
            navigation.selectOnDown = selectOnDown.value;
            navigation.selectOnUp = selectOnUp.value;
            navigation.selectOnLeft = selectOnLeft.value;
            navigation.selectOnRight = selectOnRight.value;
            selectable.navigation = navigation;
        }

    }
}