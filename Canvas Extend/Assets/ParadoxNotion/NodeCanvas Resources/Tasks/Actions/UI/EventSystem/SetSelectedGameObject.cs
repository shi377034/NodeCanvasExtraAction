using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Set Selected GameObject")]
    [Category("UI/EventSystem")]
    public class SetSelectedGameObject : ActionTask
    {
        public BBParameter<GameObject> gameObject;

        protected override void OnExecute()
        {
            EventSystem.current.SetSelectedGameObject(gameObject.value);
            EndAction();
        }
    }
}