using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    #region Fields

    // timer name
    private TimerName timerName;

    // timer duration
    private float totalSeconds = 0;

    // timer execution 
    private float elapsedSeconds = 0;
    private bool isRunning = false;

    // support for Finished property
    private bool isStarted = false;
    private bool isStopped = false;

    #endregion

    #region Propeties

    // gets timer name
    public TimerName TimerName {
        get { return timerName; }
    }

    // sets the duration of the timer
    public float Duration {
        set {
            if(!isRunning) {
                totalSeconds = value;
            }
        }
    }
    // gets left time
    public float TimeLeft {
        get {
            return totalSeconds - elapsedSeconds;
        }
    }

    /// Gets whether or not the timer has finished running
    /// This property returns false if the timer has never been started
    public bool Finished {
        get { return isStarted && !isRunning && !isStopped; }
    }

    // Gets whether or not the timer is currently running
    public bool IsRunnig {
        get { return isRunning; }
    }

    #endregion

    #region Methods

    // set timer name useing enum
    public void SetTimerName(TimerName timerName) {
        this.timerName = timerName;
    }

    private void Update() {
        
        if(IsRunnig && !isStopped) {

            elapsedSeconds += Time.deltaTime;
            if(elapsedSeconds >= totalSeconds) {

                isRunning = false;

                EventManager.TriggerEvent(EventName.TimerFinished, new EventArg(timerName));

            }
        }
    }

    /// Runs the timer
    /// Because a timer of 0 duration doesn't really make sense,
    /// the timer only runs if the total seconds is larger than 0
    /// This also makes sure the consumer of the class has actually 
    /// set the duration to something higher than 0
    public void Run() {

        // only run with valid duration
        if(totalSeconds > 0) {

            isStarted = true;
            isRunning = true;
            elapsedSeconds = 0;
        }
    }

    // stop the timer
    public void Stop() {

        isStopped = true;
        isRunning = false;
        EventManager.TriggerEvent(EventName.TimerFinished, new EventArg(timerName));
    }
    #endregion
}
