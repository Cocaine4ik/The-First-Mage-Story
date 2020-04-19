using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Event argument with custm constructors
/// </summary>
public class EventArg {

    #region Fields

    private int firstIntArg;
    private int secondIntArg;
    private string firstStringArg;
    private float firstFloatArg;
    private bool firstBoolArg;
    private TimerName timerName;
    private Quest quest;
    private Item item;

    #endregion

    #region Properties

    public int FirstIntArg => firstIntArg;
    public int SecondIntArg => secondIntArg;
    public string FirstStringArg => firstStringArg;
    public float FirstFloatArg => firstFloatArg;
    public bool FirstBoolArg => firstBoolArg;
    public TimerName TimerName => timerName;
    public Quest Quest => quest;
    public Item Item => item;

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

    public EventArg(string arg) {
        this.firstStringArg = arg;
    }
    /// <summary>
    /// construtor with quest arg
    /// </summary>
    /// <param name="name"></param>
    /// <param name="description"></param>
    public EventArg(Quest quest) {
        this.quest = quest;
    }
    /// <summary>
    /// constructor with one float arg
    /// </summary>
    /// <param name="arg"></param>
    public EventArg(float arg)
    {
        this.firstFloatArg = arg;
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
