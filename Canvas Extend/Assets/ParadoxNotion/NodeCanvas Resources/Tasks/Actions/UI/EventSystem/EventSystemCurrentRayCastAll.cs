using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Current RayCastAll")]
    [Category("UI/EventSystem")]
    public class EventSystemCurrentRayCastAll : ActionTask
    {
        public BBParameter<Vector2> orScreenPosition2d;
        [BlackboardOnly]
        public BBParameter<List<GameObject>> gameObjectList;
        [BlackboardOnly]
        public BBParameter<int> hitCount;

        private PointerEventData pointer;
        private List<RaycastResult> raycastResults = new List<RaycastResult>();
        protected override void OnExecute()
        {
            gameObjectList.value.Clear();
            pointer = new PointerEventData(EventSystem.current);
            pointer.position = orScreenPosition2d.value;

            EventSystem.current.RaycastAll(pointer, raycastResults);

            hitCount.value = raycastResults.Count;

            foreach (var _res in raycastResults)
            {
                gameObjectList.value.Add(_res.gameObject);
            }
            EndAction();
        }
    }
}