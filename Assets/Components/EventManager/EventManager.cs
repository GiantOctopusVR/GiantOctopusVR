using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour {

    private static EventManager _instance;
    public static EventManager Instance
    {
        get
        {
            if(!_instance)
            {
                _instance = FindObjectOfType<EventManager>();

                if(!_instance)
                {
                    // disabling because error message pops up when stop the game
                    //Debug.LogError("No object with an event manager found in the scene");
                }
                else
                {
                    _instance.Init();
                }
            }

            return _instance;
        }
    }

    private Dictionary<string, UnityEvent> eventDictionary;

    void Init()
    {
        if(eventDictionary == null)
        {
            eventDictionary = new Dictionary<string, UnityEvent>();
        }
    }

    public static void StartListening(string eventName, UnityAction listener)
    {
        UnityEvent thisEvent = null;

        if(!Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent = new UnityEvent();
            _instance.eventDictionary.Add(eventName, thisEvent);
        }

        thisEvent.AddListener(listener);
    }

    public static void StopListening(string eventName, UnityAction listener)
    {
        if (!Instance) return;

        UnityEvent thisEvent = null;
        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent(string eventName)
    {
        UnityEvent thisEvent = null;
        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke();
        }
    }
}
