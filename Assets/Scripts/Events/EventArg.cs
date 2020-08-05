using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;

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
    private List<string> stringListArg = new List<string>();
    private float firstFloatArg;
    private bool firstBoolArg;
    private TimerName timerName;
    private Color32 color;
    private Quest quest;
    private Story story;
    private Item item;
    private ItemName itemName;
    private ItemType itemType;
    private Spell spell;
    private SupplyItem supply;
    private Sprite sprite;
    private GameObject gameObject;
    private InventoryCell cell;

    #endregion

    #region Properties

    public int FirstIntArg => firstIntArg;
    public int SecondIntArg => secondIntArg;
    public string FirstStringArg => firstStringArg;
    public string SecondStringArg => secondStringArg;
    public string ThirdStringArg => thirdStringArg;
    public List<string> StringListArg => stringListArg;
    public float FirstFloatArg => firstFloatArg;
    public bool FirstBoolArg => firstBoolArg;
    public TimerName TimerName => timerName;
    public Color32 Color => color;
    public Quest Quest => quest;
    public Story Story => story;
    public Item Item => item;
    public ItemName ItemName => itemName;
    public ItemType ItemType => itemType;
    public Spell Spell => spell;
    public SupplyItem Supply => supply;
    public Sprite Sprite => sprite;
    public GameObject GameObject => gameObject;
    public InventoryCell Cell => cell;

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
    /// constructor with color arg
    /// </summary>
    /// <param name="arg"></param>
    public EventArg(Color32 arg) {
        this.color = arg;
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
    ///  constructor with list of strings
    /// </summary>
    /// <param name="arg"></param>
    public EventArg(List<string> arg) {
        this.stringListArg.AddRange(arg);
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

    // constructor with ItemName and ItemType
    public EventArg(ItemName name, ItemType type) {
        this.itemName = name;
        this.itemType = type;
    }
    // constructor with Spell
    public EventArg(Spell spell) {
        this.spell = spell;
    }
    // constructor with supply item
    public EventArg (SupplyItem supply)
    {
        this.supply = supply;
    }

    // constructor for spellCell
    public EventArg(int id, Sprite icon, Spell spell) {
        this.firstIntArg = id;
        this.sprite = icon;
        this.spell = spell;

    }

    // constructor for supply cell
    public EventArg(int id, InventoryCell cell, SupplyItem supply)
    {
        this.firstIntArg = id;
        this.cell = cell;
        this.supply = supply;

    }

    // constructor for gamrojects
    public EventArg(GameObject gameObject) {
        this.gameObject = gameObject;
    }
    // // constructor with sprite
    public EventArg(Sprite sprite)
    {
        this.sprite = sprite;
    }
    #endregion
}
