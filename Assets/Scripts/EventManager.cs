using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is responsible for creating events that can be triggered and picked up by other scripts
public class EventManager : MonoBehaviour
{
    #region Fields

    // Create a singleton instance of EventManager
    private static EventManager _instance;

    private static bool applicationIsQuitting = false;

    // Get a singleton instance of EventManager
    public static EventManager Instance
    {
        get
        {
            if(applicationIsQuitting)
            {
                // Gives a signal to scripts calling EventManager that
                // the application is closing and EventManager is being
                // destroyed to prevent runtime errors
                return null;
            }
            else if(_instance == null)
            {
                GameObject go = new GameObject("EventManager");
                go.AddComponent<EventManager>();
                DontDestroyOnLoad(go);
            }

            return _instance;
        }
    }

    #endregion

    #region Unity Methods

    // Awake is called when the object in instanciated
    void Awake()
    {
        _instance = this;
    }

    // Runs when the object gets destroyed
    public void OnDestroy()
    {
        applicationIsQuitting = true;
    }

    #endregion

    #region Events

    // Creates an event called some event that other scripts can subscribe to.
    // Other scripts can call EventManager.Instance.OnSomeEvent += MethodName; (do in OnEnable method)
    // or EventManager.Instance.OnSomeEvent -= MethodName; (do in OnDisable method)
    // to subscribe to the event.
    // To call the event from another script,
    // Have the script call EventManager.Instance.SomeEvent();

    /// <summary>
    /// Signals that all movement but the bird should stop
    /// </summary>
    public event Action OnStopMovement;
    public void StopMovement()
    {
        if(OnStopMovement != null)
        {
            OnStopMovement();
        }
    }

    #endregion
}
