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
    private string secondStringArg;
    private string thirdStringArg;
    private float firstFloatArg;
    private bool firstBoolArg;
    private TimerName timerName;
    private Quest quest;
    private Story story;
    private Item item;

    #endregion

    #region Properties

    public int FirstIntArg => firstIntArg;
    public int SecondIntArg => secondIntArg;
    public string FirstStringArg => firstStringArg;
    public string SecondStringArg => secondStringArg;
    public string ThirdStringArg => thirdStringArg;
    public float FirstFloatArg => firstFloatArg;
    public bool FirstBoolArg => firstBoolArg;
    public TimerName TimerName => timerName;
    public Quest Quest => quest;
    public Story Story => story;
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
    /// <summary>
    /// constructor with string arg
    /// </summary>
    /// <param name="arg"></param>
    public EventArg(string arg) {
        this.firstStringArg = arg;
    }
    /// <summary>
    /// constructor with three string arg
    /// </summary>
    /// <param name="arg"></param>
    /// <param name="arg2"></param>
    /// <param name="arg3"></param>
    public EventArg(string arg, string arg2, string arg3) {
        this.firstStringArg = arg;
        this.secondStringArg = arg2;
        this.thirdStringArg = arg3;
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
    /// 
    /// </summary>
    /// <param name="story"></param>
    public EventArg(Story story) {
        this.story = story;
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
