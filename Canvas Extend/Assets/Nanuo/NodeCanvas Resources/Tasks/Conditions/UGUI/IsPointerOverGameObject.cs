using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace NodeCanvas.Tasks.Conditions
{

    [Category("UGUI")]
    public class IsPointerOverGameObject : ConditionTask
    {
        public BBParameter<bool> value;

        protected override string info
        {
            get { return string.Format("IsPointerOverGameObject == {0}", value); }
        }

        protected override bool OnCheck()
        {

            return EventSystem.current.IsPointerOverGameObject() == value.value;
        }
    }
}