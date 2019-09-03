using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventArg {

    #region Fields

    private int firstIntArg;
    private int secondIntArg;
    private bool firstBoolArg;
    private TimerName timerName;
    private Item item;

    #endregion

    #region Properties

    public int FirstIntArg { get { return firstIntArg; } }

    public int SecondIntArg {  get { return secondIntArg; } }
    public bool FirstBoolArg { get { return firstBoolArg; } }
    public TimerName TimerName { get { return timerName; } }
    public Item Item { get { return item; } }

    #endregion

    #region Constructors

    // default constructor
    public EventArg() {
    }

    // constructor with one int arg
    public EventArg(int arg) {
        this.firstIntArg = arg;
    }

    // constructor with two int arg
    public EventArg(int arg, int arg2)
    {
        this.firstIntArg = arg;
        this.secondIntArg = arg2;
    }

    // constructor with one bool arg
    public EventArg(bool arg) {
        this.firstBoolArg = arg;
    }

    // constructor with TimerName
    public EventArg(TimerName timerName) {
        this.timerName = timerName;
    }

    // constructor with Item
    public EventArg(Item item) {
        this.item = item;
    }
    #endregion
}
