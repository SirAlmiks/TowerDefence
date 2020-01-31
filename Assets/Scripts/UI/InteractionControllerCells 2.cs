﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractionControllerCells : MonoBehaviour
{
    //TODO - изменить алгоритм постройки
    //СНАЧАЛА - выбирается ячейка куда строить/улучшать
    //ЗАТЕМ - выбирается башня/улучшение

    public Color hoverColor; //Цвет подсветки ячейки в тактическом режиме
    public Color notEnoughtMoneyColor; //Цвет подсветки ячейки в тактическом режиме если не хватает денег
    public Vector3 offsetPosition = new Vector3(0f,0.2f,0f); //корректировка установки башни
    public float quadronHoverColor = 0.2f; //корректировка яркости при наводе на квадрат
                                            //в стратегическом режиме
    [HideInInspector]
    public GameObject turret; //туррель в ячейке
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer rend; //цвет ячейки
    private Color startColor; //изначальный цвет
    
    BuildManager buildManager;
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color; //сохранение базового цвета
        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition () {
        return transform.position + offsetPosition;
    }

    void OnMouseDown () { //события при нажатии на мышь
        if (EventSystem.current.IsPointerOverGameObject()) //Проверка, что бы не взаимодействовать сквозь UI
            return;
        
        if (gameObject.tag == "Road") //с дорогой нельзя взаимодействовать
            return;

        if (turret != null) { //Выбор туррели, если она есть в ячейке
            buildManager.SelectCell(this);
            return;
        }

        if (!buildManager.CanBuild) //Если не можем строить, ничего не делаем
            return;

        //Создание башни, которая выбрана
        BuildTower(buildManager.GetTurretToBuild());
    }

    
    void BuildTower(TurretBlueprint blueprint) {
         if (PlayerStats.Money < blueprint.cost) { //Если не хватает средств - не строим
            Debug.Log("Not enough shards to build that."); //Вывести на экран сообщение
            return;
        }

        PlayerStats.Money -= blueprint.cost; //снятие средств за постройку башни

        GameObject _turret = Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;

        GameObject beffect = Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(beffect, 0.5f); //Сотворить и уничтожить эффект постройки

        Debug.Log("The turret build. Shards left: " + PlayerStats.Money);
    }

    public void UpgradeTower() {
         if (PlayerStats.Money < turretBlueprint.upgradeCost) { //Если не хватает средств - не улучшаем
            Debug.Log("Not enough shards to upgrade that."); //Вывести на экран сообщение
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost; //снятие средств за ekexitybt башни

        //Уничтожение старой туррели
        Destroy(turret);

        //Постройка улучшенной
        GameObject _turret = Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject beffect = Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(beffect, 0.5f);

        isUpgraded = true;

        Debug.Log("The turret upgraded. Shards left: " + PlayerStats.Money);
    }

    public void SellTurret() {
        if (!isUpgraded)
        PlayerStats.Money += turretBlueprint.GetSellAmount();
        else
        PlayerStats.Money += turretBlueprint.GetUpgradeSellAmount();

        //TODO add cool effect

        Destroy(turret);
        turretBlueprint = null;
        isUpgraded = false;
    }

    void OnMouseEnter() { //подствека при наводке ячейки
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        
        if (gameObject.tag == "Road") //с дорогой нельзя взаимодействовать
            return;

        if (!buildManager.CanBuild) //Если не можем строить, ничего не делаем
            return;

        if (buildManager.HasMoney)
            rend.material.color = hoverColor;
        else
            rend.material.color = notEnoughtMoneyColor;
    }


    void OnMouseExit() { //возвращение стандартного цвета при выводе мыши с ячейки
        StandartHoverColor();
    }
    public void QuadreHoverColor() { //подсветка квадрата ячеек в стратегическом режиме
        rend.material.color = new Color(rend.material.color.r + quadronHoverColor,
                                        rend.material.color.g + quadronHoverColor,
                                        rend.material.color.b + quadronHoverColor,
                                        rend.material.color.a);
    }

    public void StandartHoverColor() { //возвращение цвета ячеек
        rend.material.color = startColor;
    }
}
