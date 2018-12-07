using UnityEngine;
using System.Collections;
using ParadoxNotion;
using ParadoxNotion.Services;

public static class MessageRouterExtensions
{
    public static void Dispatch(this GameObject gameObject, string message)
    {
        MessageRouter messageRouter = gameObject.GetComponent<MessageRouter>();
        if (messageRouter)
        {
            messageRouter.Dispatch(message);
        }
    }
    public static void Dispatch<T>(this GameObject gameObject, string message, T arg)
    {
        MessageRouter messageRouter = gameObject.GetComponent<MessageRouter>();
        if (messageRouter)
        {
            messageRouter.Dispatch(message, arg);
        }
    }
    public static void Dispatch(this Component component, string message)
    {
        MessageRouter messageRouter = component.GetComponent<MessageRouter>();
        if (messageRouter)
        {
            messageRouter.Dispatch(message);
        }
    }
    public static void Dispatch<T>(this Component component, string message, T arg)
    {
        MessageRouter messageRouter = component.GetComponent<MessageRouter>();
        if (messageRouter)
        {
            messageRouter.Dispatch(message, arg);
        }
    }
    public static void OnCustomEvent(this GameObject gameObject, EventData eventData)
    {
        MessageRouter messageRouter = gameObject.GetComponent<MessageRouter>();
        if (messageRouter)
        {
            messageRouter.OnCustomEvent(eventData);
        }
    }
    public static void OnCustomEvent(this Component component, EventData eventData)
    {
        MessageRouter messageRouter = component.GetComponent<MessageRouter>();
        if(messageRouter)
        {
            messageRouter.OnCustomEvent(eventData);
        }
    }
    public static void OnCustomEvent(this GameObject gameObject, string message)
    {
        MessageRouter messageRouter = gameObject.GetComponent<MessageRouter>();
        if (messageRouter)
        {
            messageRouter.OnCustomEvent(new EventData(message));
        }
    }
    public static void OnCustomEvent(this Component component, string message)
    {
        MessageRouter messageRouter = component.GetComponent<MessageRouter>();
        if (messageRouter)
        {
            messageRouter.OnCustomEvent(new EventData(message));
        }
    }
    public static void OnCustomEvent<T>(this Component component, string message, T arg)
    {
        MessageRouter messageRouter = component.GetComponent<MessageRouter>();
        if (messageRouter)
        {
            messageRouter.OnCustomEvent(new EventData<T>(message, arg));
        }
    }
    public static void OnCustomEvent<T>(this GameObject gameObject, string message, T arg)
    {
        MessageRouter messageRouter = gameObject.GetComponent<MessageRouter>();
        if (messageRouter)
        {
            messageRouter.OnCustomEvent(new EventData<T>(message, arg));
        }
    }
    public static void SendEvent(this Component component, string eventName)
    {
        component.OnCustomEvent(eventName);
    }
    public static void SendEvent<T>(this Component component, string eventName, T eventValue)
    {
        component.OnCustomEvent(eventName, eventValue);
    }
    public static void SendEvent(this GameObject gameObject, string eventName)
    {
        gameObject.OnCustomEvent(eventName);
    }
    public static void SendEvent<T>(this GameObject gameObject, string eventName, T eventValue)
    {
        gameObject.OnCustomEvent(eventName, eventValue);
    }
}
