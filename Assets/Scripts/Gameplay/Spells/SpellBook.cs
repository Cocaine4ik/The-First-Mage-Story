using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SpellBook : UIElementBase
{
    [SerializeField] private TextMeshProUGUI spellPointsValue;
    [SerializeField] private List<GameObject> spellTrees;
    [SerializeField] private List<GameObject> specialSpells;

    [SerializeField] private Button veilMagicButton;
    [SerializeField] private Button natureMagicButton;
    [SerializeField] private Button runeMagicButton;
    [SerializeField] private Button divineMagicButton;
    [SerializeField] private Button spiritMagicButton;


    private void OnEnable() {
        EventManager.StartListening(EventName.RefreshSpellBook, OnRefreshSpellbook);
    }

    private void OnDisable() {
        EventManager.StopListening(EventName.RefreshSpellBook, OnRefreshSpellbook);
    }

    protected override void Start() {
        base.Start();
        RefreshSpellPoints();

        veilMagicButton.onClick.AddListener(() => OpenVeilMagicSpellTree());
        natureMagicButton.onClick.AddListener(() => OpenNatureMagicSpellTree());
        runeMagicButton.onClick.AddListener(() => OpenRuneMagicSpellTree());
        divineMagicButton.onClick.AddListener(() => OpenDivineMagicSpellTree());
        spiritMagicButton.onClick.AddListener(() => OpenSpiritMagicSpellTree());

    }
    private void OnRefreshSpellbook(EventArg arg) {
        RefreshSpellPoints();
    }

    private void RefreshSpellPoints() {
        spellPointsValue.text = Attributes.Instance.SpellPoints.ToString();
    }

    private void ChangeSpellTree(GameObject activeSpelltree, GameObject activeSpecialSpell) {

        foreach(GameObject spellTree in spellTrees) {
            spellTree.SetActive(false);
        }
        foreach (GameObject specialSpell in specialSpells) {
            specialSpell.SetActive(false);
        }
        activeSpelltree.SetActive(true);
        activeSpecialSpell.SetActive(true);

    }
    /// Open Magic Spell Tree OnClick events
    private void OpenVeilMagicSpellTree() {
        ChangeSpellTree(spellTrees[0], specialSpells[0]);
    }
    private void OpenNatureMagicSpellTree() {
        ChangeSpellTree(spellTrees[1], specialSpells[1]);
    }
    private void OpenRuneMagicSpellTree() {
        ChangeSpellTree(spellTrees[2], specialSpells[2]);
    }
    private void OpenDivineMagicSpellTree() {
        ChangeSpellTree(spellTrees[3], specialSpells[3]);
    }
    private void OpenSpiritMagicSpellTree() {
        ChangeSpellTree(spellTrees[4], specialSpells[4]);
    }
}
