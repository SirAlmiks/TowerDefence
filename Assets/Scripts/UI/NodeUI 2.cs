using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    private InteractionControllerCells cell;
    public Text upgradeCost;
    public Text sellCost;
    public Button upgradeButton;
    public GameObject ui;

    public void SetTarget (InteractionControllerCells _cell) {
        cell = _cell;

        transform.position = cell.GetBuildPosition();

        if(!cell.isUpgraded) {
            upgradeCost.text = "$" + cell.turretBlueprint.upgradeCost; //стоимость улучшения
            sellCost.text = "$" + cell.turretBlueprint.GetSellAmount(); //стоимость продажи
            upgradeButton.interactable = true;
        }
        else {
            upgradeCost.text = "DONE"; //отображение, что улучшение зеавершено
            sellCost.text = "$" + cell.turretBlueprint.GetUpgradeSellAmount(); 
            upgradeButton.interactable = false; //кнопка улучшения невозможна для взаимодействия
        }

         ui.SetActive(true);
    }

    public void Hide() {
        ui.SetActive(false);
    }

    public void Upgrade() { //кнопка улучшения
        cell.UpgradeTower();
        BuildManager.instance.DeselectCell();
    }

    public void Sell() { //кнопка продажи
        cell.SellTurret();
        BuildManager.instance.DeselectCell();
    }
}
