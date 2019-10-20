using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Get Selected GameObject")]
    [Category("UI/EventSystem")]
    public class GetSelectedGameObject : ActionTask
    {
        [BlackboardOnly]
        public BBParameter<GameObject> StoreGameObject;

        protected override void OnExecute()
        {
            StoreGameObject.value = EventSystem.current.currentSelectedGameObject;
            EndAction();
        }
    }
}