using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnMouseOverUI : MonoBehaviour, IPointerEnterHandler {

    private List<string> descriptionKeys;
    private string pointedGameObjectName = null;
    private string modifier = " ";

    private const string skillDescriptionKey = "UI.CharacterMenu.Description.";
    private const string skillDescriptionExtraOneKey = "UI.CharacterMenu.Description.Extra.1.";
    private const string skillDescriptionExtraSecondKey = "UI.CharacterMenu.Description.Extra.2.";

    private Projectile projectile;
    private void Start() {

        descriptionKeys = new List<string> {
            skillDescriptionKey + gameObject.name,
            skillDescriptionExtraOneKey + gameObject.name,
            skillDescriptionExtraSecondKey + gameObject.name
        };

        projectile = Attributes.Instance.gameObject.GetComponent<Player>().ProjectilePrefab.GetComponent<Projectile>();
    }
    public void OnPointerEnter(PointerEventData eventData) {
        pointedGameObjectName = gameObject.name;

        if (pointedGameObjectName == gameObject.name) {

            Debug.Log(gameObject.name);
            modifier = Setmodifier(pointedGameObjectName);
            var stringArgList = descriptionKeys;
            stringArgList.Add(modifier);
            EventManager.TriggerEvent(EventName.SetSkillDescription, new EventArg(stringArgList));

        }
        else pointedGameObjectName = null;
    }  
    
    private string Setmodifier(string name) {

        switch(name) {
            case "Knowledge":
                modifier = $"{projectile.Damage - Attributes.Instance.Knowledge}" +
                    $" + {Attributes.Instance.Knowledge}"; break;
            case "Wisdom":
                modifier = $"{Attributes.Instance.Wisdom * ConfigurationUtils.ManaByWisdomPoint}"; break;
            case "Spirit":
                modifier = $"{Attributes.Instance.Spirit * ConfigurationUtils.HealthBySpiritPoint}"; break;
            case "Faith":
                modifier = $"{Attributes.Instance.MiracleChance}%"; break;
        }
        return modifier;
    }
}
