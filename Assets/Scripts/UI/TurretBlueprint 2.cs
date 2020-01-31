using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TurretBlueprint //Не является обработчиком и не взаимодействует с другими объектами. Убран MonoBehavior
{
    //TODO - добавить вариации улучшений туррели в будущем. И ответвления
    public GameObject prefab;
    public int cost;
    public Text costText;

    public GameObject upgradedPrefab;
    public int upgradeCost;
    public Text upgradeCostText;

    void Start() {
        costText.text = "$" + cost.ToString();
        upgradeCostText.text = "$" + cost.ToString();
    }

    public int GetSellAmount() { //количество средств с продажи
        return cost / 2;
    }
    public int GetUpgradeSellAmount() { //с продажи с улучшением
        return (cost / 2) + (upgradeCost / 2);
    } 
}
