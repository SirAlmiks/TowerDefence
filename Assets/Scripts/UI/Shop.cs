using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public TurretBlueprint baseTurret;
    public TurretBlueprint heavyCannon;
    public TurretBlueprint laserTurret;
    public TurretBlueprint repairTower;

    //TODO - Добавить исчезновение панельки в тактическом режиме
    BuildManager buildManager;

    void Start() {
        buildManager = BuildManager.instance;

    }
    public void SelectStandartTurret() { //Выбор туррели для покупки
        Debug.Log("Buy Standart Turret");
        buildManager.SelectTurretToBuild(baseTurret);
    }

    public void SelectHeavyCannonTurret() {
        Debug.Log("Buy Heavy Cannon Turret");
        buildManager.SelectTurretToBuild(heavyCannon);
    }

    public void SelectLaserTurret() {
        Debug.Log("Buy Laser Turret");
        buildManager.SelectTurretToBuild(laserTurret);
    }

    public void SelectRepairTower()
    {
        Debug.Log("Buy Repair Tower");
        buildManager.SelectTurretToBuild(repairTower);
    }
}
