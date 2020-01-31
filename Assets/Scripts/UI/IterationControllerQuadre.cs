using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class IterationControllerQuadre : MonoBehaviour
{
    public MapGlobalStatus mGS; //глобальный статус карты                                                            
                                //для определения позиции камеры в игре
                                //возможно введение доп. функций
    public BoxCollider boxCollider;
    public InteractionControllerCells[] allFuncChildren; //сбор всех скриптов ячеек квадрата
    public CameraController cam;
    public GameObject topPanel;
    public GameObject rightPanel;
    public GameObject shop;
    void Start() {
        mGS = MapGlobalStatus.instance;
        allFuncChildren = GetComponentsInChildren<InteractionControllerCells>();
        boxCollider = GetComponent<BoxCollider>();
    }

    void Update () {
         if (mGS.levelScreenMode == 0 && !boxCollider.enabled)
            boxCollider.enabled = true;
         if (mGS.levelScreenMode == 1 && boxCollider.enabled)
            boxCollider.enabled = false; //исключение коллайдера, для активации коллайдеров ячеек
    }
    void OnMouseEnter() { //подствека целого квадрата
        if (EventSystem.current.IsPointerOverGameObject()) //Проверка, что бы не взаимодействовать сквозь UI
            return;

        foreach (InteractionControllerCells child in allFuncChildren)
        {
        child.QuadreHoverColor();
        }
            
    }

    void OnMouseExit() { //возвращение цвета
        foreach (InteractionControllerCells child in allFuncChildren)
        {
        child.StandartHoverColor();
        }
            
    }
    void OnMouseDown() { //при клике перемещение к указанному квадрату
        if (EventSystem.current.IsPointerOverGameObject()) //Проверка, что бы не взаимодействовать сквозь UI
            return;

        if (mGS.levelScreenMode == 0) {
            cam.LookAtQuadron(transform.position);
            mGS.levelScreenMode = 1; //изменение статуса со стратегического на тактический
            topPanel.SetActive(true);
            rightPanel.SetActive(true);
            shop.SetActive(true);
        }
    }

}
