using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEventManager : MonoBehaviour
{
    // event bus for player

    public enum InvEventType
    {
        ADD,
        DROP,
        USE,
        TRANSFER
    }

    private static readonly IDictionary<InvEventType, UnityEvent> invEvents = new Dictionary<InvEventType, UnityEvent>();

    public static void InvSubscribe(InvEventType eventType, UnityAction listener)
    {
        UnityEvent thisEvent;

        if (invEvents.TryGetValue(eventType, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            invEvents.Add(eventType, thisEvent);
        }

    }

    public static void InvUnsubscribe(InvEventType eventType, UnityAction listener)
    {
        UnityEvent thisEvent;

        if (invEvents.TryGetValue(eventType, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void InvPublish(InvEventType eventType)
    {
        UnityEvent thisEvent;

        if (invEvents.TryGetValue(eventType, out thisEvent))
        {
            thisEvent.Invoke();
        }
    }
}
