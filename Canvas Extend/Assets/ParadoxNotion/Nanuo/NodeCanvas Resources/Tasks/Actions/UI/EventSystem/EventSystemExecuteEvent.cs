using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace NodeCanvas.Tasks.Actions
{
    [Name("ExecuteEvent")]
    [Category("UI/EventSystem")]
    public class EventSystemExecuteEvent : ActionTask<GameObject>
    {
        public enum EventHandlers
        {
            Submit,
            beginDrag,
            cancel,
            deselectHandler,
            dragHandler,
            dropHandler,
            endDragHandler,
            initializePotentialDrag,
            pointerClickHandler,
            pointerDownHandler,
            pointerEnterHandler,
            pointerExitHandler,
            pointerUpHandler,
            scrollHandler,
            submitHandler,
            updateSelectedHandler
        }
        public BBParameter<EventHandlers> eventHandler= EventHandlers.Submit;
        public BBParameter<string> success;
        public BBParameter<string> canNotHandleEvent;
        private GameObject go;
        protected override void OnExecute()
        {
            this.SendEvent(ExecuteEvent() ? success.value : canNotHandleEvent.value);
            EndAction();
        }
        private bool ExecuteEvent()
        {
            go = agent;

            var handlerType = eventHandler.value;

            switch (handlerType)
            {
                case EventHandlers.Submit:
                    if (!ExecuteEvents.CanHandleEvent<ISubmitHandler>(go)) return false;
                    ExecuteEvents.Execute(go, new BaseEventData(EventSystem.current), ExecuteEvents.submitHandler);
                    break;

                case EventHandlers.beginDrag:
                    if (!ExecuteEvents.CanHandleEvent<IBeginDragHandler>(go)) return false;
                    ExecuteEvents.Execute(go, new BaseEventData(EventSystem.current), ExecuteEvents.beginDragHandler);
                    break;

                case EventHandlers.cancel:
                    if (!ExecuteEvents.CanHandleEvent<ICancelHandler>(go)) return false;
                    ExecuteEvents.Execute(go, new BaseEventData(EventSystem.current), ExecuteEvents.cancelHandler);
                    break;

                case EventHandlers.deselectHandler:
                    if (!ExecuteEvents.CanHandleEvent<IDeselectHandler>(go)) return false;
                    ExecuteEvents.Execute(go, new BaseEventData(EventSystem.current), ExecuteEvents.deselectHandler);
                    break;

                case EventHandlers.dragHandler:
                    if (!ExecuteEvents.CanHandleEvent<IDragHandler>(go)) return false;
                    ExecuteEvents.Execute(go, new BaseEventData(EventSystem.current), ExecuteEvents.dragHandler);
                    break;

                case EventHandlers.dropHandler:
                    if (!ExecuteEvents.CanHandleEvent<IDropHandler>(go)) return false;
                    ExecuteEvents.Execute(go, new BaseEventData(EventSystem.current), ExecuteEvents.dropHandler);
                    break;

                case EventHandlers.endDragHandler:
                    if (!ExecuteEvents.CanHandleEvent<IEndDragHandler>(go)) return false;
                    ExecuteEvents.Execute(go, new BaseEventData(EventSystem.current), ExecuteEvents.endDragHandler);
                    break;

                case EventHandlers.initializePotentialDrag:
                    if (!ExecuteEvents.CanHandleEvent<IInitializePotentialDragHandler>(go)) return false;
                    ExecuteEvents.Execute(go, new BaseEventData(EventSystem.current), ExecuteEvents.initializePotentialDrag);
                    break;

                case EventHandlers.pointerClickHandler:
                    if (!ExecuteEvents.CanHandleEvent<IPointerClickHandler>(go)) return false;
                    ExecuteEvents.Execute(go, new BaseEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
                    break;

                case EventHandlers.pointerDownHandler:
                    if (!ExecuteEvents.CanHandleEvent<IPointerDownHandler>(go)) return false;
                    ExecuteEvents.Execute(go, new BaseEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
                    break;

                case EventHandlers.pointerUpHandler:
                    if (!ExecuteEvents.CanHandleEvent<IPointerUpHandler>(go)) return false;
                    ExecuteEvents.Execute(go, new BaseEventData(EventSystem.current), ExecuteEvents.pointerUpHandler);
                    break;

                case EventHandlers.pointerEnterHandler:
                    if (!ExecuteEvents.CanHandleEvent<IPointerEnterHandler>(go)) return false;
                    ExecuteEvents.Execute(go, new BaseEventData(EventSystem.current), ExecuteEvents.pointerEnterHandler);
                    break;

                case EventHandlers.pointerExitHandler:
                    if (!ExecuteEvents.CanHandleEvent<IPointerExitHandler>(go)) return false;
                    ExecuteEvents.Execute(go, new BaseEventData(EventSystem.current), ExecuteEvents.pointerExitHandler);
                    break;

                case EventHandlers.scrollHandler:
                    if (!ExecuteEvents.CanHandleEvent<IScrollHandler>(go)) return false;
                    ExecuteEvents.Execute(go, new BaseEventData(EventSystem.current), ExecuteEvents.scrollHandler);
                    break;

                case EventHandlers.updateSelectedHandler:
                    if (!ExecuteEvents.CanHandleEvent<IUpdateSelectedHandler>(go)) return false;
                    ExecuteEvents.Execute(go, new BaseEventData(EventSystem.current), ExecuteEvents.updateSelectedHandler);
                    break;
            }

            return true;

        }
    }
}