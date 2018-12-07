using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Get Navigation Properties")]
    [Category("UI/Selectable")]
    public class NavigationExplicitGetProperties : ActionTask<Selectable>
    {
        [BlackboardOnly]
        public BBParameter<GameObject> selectOnDown;
        [BlackboardOnly]
        public BBParameter<GameObject> selectOnUp;
        [BlackboardOnly]
        public BBParameter<GameObject> selectOnLeft;
        [BlackboardOnly]
        public BBParameter<GameObject> selectOnRight;
        private Selectable _selectable;
        protected override void OnExecute()
        {
            _selectable = agent;
            DoGetValue();
            EndAction();
        }
        private void DoGetValue()
        {
            if (_selectable != null)
            {
                selectOnUp.value = _selectable.navigation.selectOnUp.gameObject;
                selectOnDown.value = _selectable.navigation.selectOnDown.gameObject;
                selectOnLeft.value = _selectable.navigation.selectOnLeft.gameObject;
                selectOnRight.value = _selectable.navigation.selectOnRight.gameObject;
            }
        }
    }
}