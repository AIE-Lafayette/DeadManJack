using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The way the timed action will keep track of time.
/// </summary>
public enum TimedActionCountType
{
    /// <summary>
    /// Scaled time is time that can be affected by the global time scale.
    /// </summary>
    SCALEDTIME,

    /// <summary>
    /// Unscaled time is time that is not affected by the global time scale.
    /// </summary>
    UNSCALEDTIME,

    /// <summary>
    /// This is used to measure the amount of frames that have passed.
    /// </summary>
    FRAME
}

public class RoutineBehavior : MonoBehaviour
{
    /// <summary>
    /// An event thats called when a timer is up.
    /// </summary>
    /// <param name="args"> Any additional arguments for the timed event. </param>
    public delegate void TimedEvent(params object[] args);

    /// <summary>
    /// An object that rasies an event after a given duration.
    /// </summary>
    public class TimedAction
    {
        private bool _isActive;
        public float TimedStarted;
        public float Duration;
        public TimedActionCountType CountType;
        public TimedEvent Event;

        public bool IsActive { get => _isActive; set => _isActive = value; }

        public TimedAction(TimedEvent timedEvent, TimedActionCountType countType, float duration)
        {
            Event = timedEvent;
            CountType = countType;
            Duration = duration;
        }
    }

    private List<TimedAction> _timedActions = new List<TimedAction>();

    private static RoutineBehavior _instance;

    public static RoutineBehavior Instance
    {
        get 
        {
            if(!_instance)
            {
                _instance = FindObjectOfType<RoutineBehavior>();
            }

            if(!_instance)
            {
                GameObject timer = new GameObject("TimerObject");
                _instance = timer.AddComponent<RoutineBehavior>();
            }

            return _instance;
        }
    }

    /// <summary>
    /// Calls the given event after the given amount of time or frames has passed.
    /// </summary>
    /// <param name="timedEvent"> The action to do once the timer is complete. </param>
    /// <param name="countType"> The type of counter to create. </param>
    /// <param name="duration"> How long to wait before performing the action. </param>
    /// <returns> The new action created. Can be used to pause or cancel timers. </returns>
    public TimedAction StartNewTimedAction(TimedEvent timedEvent, TimedActionCountType countType, float duration)
    {
        // Create a new timed action.
        TimedAction action = new TimedAction(timedEvent, countType, duration);

        // Initialize the start time based on the count type.
        switch (countType)
        {
            case TimedActionCountType.SCALEDTIME:
                action.TimedStarted = Time.time;
                break;
            case TimedActionCountType.UNSCALEDTIME:
                action.TimedStarted = Time.unscaledTime;
                break;
            case TimedActionCountType.FRAME:
                action.TimedStarted = Time.frameCount;
                break;
        }

        // Mark the action active and add it to the list of actions.
        action.IsActive = true;
        _timedActions.Add(action);

        // Return the new action for debugging purposes.
        return action;
    }

    /// <summary>
    /// Stops the given timed action; preventing the even from being called.
    /// </summary>
    /// <param name="action"> The timed action to stop. </param>
    /// <returns> False if the action is not in the list of actions. </returns>
    public bool StopTimedAction(TimedAction action)
    {
        if (action == null)
            return false;

        action.IsActive = false;

        return _timedActions.Remove(action);
    }

    /// <summary>
    /// Raises the event of the timed action at the given index if its timer is up.
    /// </summary>
    /// <param name="currentTime"> The current time measurement based on the actions count type. </param>
    /// <param name="index"> The index of the action in the actions list. </param>
    private void TryInvokeTimedEvent(float currentTime, int index)
    {
        TimedAction action = _timedActions[index];

        // If the timer is up and the action is active...
        if (currentTime - action.TimedStarted >= action.Duration && action.IsActive)
        {
            // ...raise the action's event and remove it from the list.
            action.IsActive = false;
            action.Event.Invoke();
            _timedActions.Remove(action);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Iterate through all actions to try to raise their events.
        for(int i = 0; i < _timedActions.Count; i++)
        {
            TimedAction currentAction = _timedActions[i];

            // Try to invoke the event based on the type of counter.
            switch (currentAction.CountType)
            {
                case TimedActionCountType.SCALEDTIME:
                    TryInvokeTimedEvent(Time.time, i);
                    break;
                case TimedActionCountType.UNSCALEDTIME:
                    TryInvokeTimedEvent(Time.unscaledTime, i);
                    break;
                case TimedActionCountType.FRAME:
                    TryInvokeTimedEvent(Time.frameCount, i);
                    break;
            }
        }
    }
    
    /// <summary>
    /// Stops all timed actions
    /// </summary>
    public void StopAllTimedActions()
    {
        for (int i = 0; i < _timedActions.Count; i++)
            StopTimedAction(_timedActions[i]);
    }
}