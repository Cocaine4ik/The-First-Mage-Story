using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class GameEvent : UnityEvent<EventArg>
{
}

/// <summary>
/// Event Manager using Unity Event with EventArg like argument
/// </summary>
/// 
public class EventManager : MonoBehaviour {

    #region Fields

    // create new dictionary with events and their names on string
    private Dictionary<EventName, GameEvent> eventDictionary;

    public static EventManager Instance;

    #endregion

    #region Methods

    private void Awake() {
        if (Instance == null) {

            Instance = this;
            eventDictionary = new Dictionary<EventName, GameEvent>();
        }
        else if (Instance != this) {

            Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }
    }
    // add listener to dictionary
    public static void StartListening(EventName eventName, UnityAction<EventArg> listener) {

        GameEvent thisEvent = null;
        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent)) {

            thisEvent.AddListener(listener);
        }
        else {
            thisEvent = new GameEvent();
            thisEvent.AddListener(listener);
            Instance.eventDictionary.Add(eventName, thisEvent);
        }
    }
    // delete listener from the dictionary
    public static void StopListening(EventName eventName, UnityAction<EventArg> listener) {

        if (Instance == null) return;
        GameEvent thisEvent = null;

        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent)) {

            thisEvent.RemoveListener(listener);
        }
    }
    // invoke event from the dictionary
    public static void TriggerEvent(EventName eventName, EventArg arg) {

        GameEvent thisEvent = null;

        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent)) {

            thisEvent.Invoke(arg);
        }
    }

    public static void TriggerEvent(EventName eventName) {

        GameEvent thisEvent = null;

        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent)) {

            thisEvent.Invoke(new EventArg());
        }
    }

    #endregion
}
