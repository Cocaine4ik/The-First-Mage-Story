using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventArg {

    #region Fields

    private int firstIntArg;
    private bool firstBoolArg;
    private TimerName timerName;

    #endregion

    #region Properties

    public int FirstIntArg { get { return firstIntArg; } }
    public bool FirstBoolArg { get { return firstBoolArg; } }
    public TimerName TimerName { get { return timerName; } }

    #endregion

    #region Constructors

    // default constructor
    public EventArg() {
    }

    // constructor with one int arg
    public EventArg(int arg) {
        this.firstIntArg = arg;
    }

    // constructor with one bool arg
    public EventArg(bool arg) {
        this.firstBoolArg = arg;
    }

    // constructor with TimerName
    public EventArg(TimerName timerName) {
        this.timerName = timerName;
    }
    #endregion
}
