using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGlobalStatus : MonoBehaviour
{
     public static MapGlobalStatus instance;
    //глобальный код для определения статуса карты

    void Awake()
    {
        if (instance != null) {
            Debug.LogError("Ошибка: Более одного MapGlobalStatus на сцене");
            return;
        }    
        instance = this;
    }
    public int levelScreenMode = 1;
    //Определение на каком уровне камера, для взаимодействия с объектами
    //0 - стратегическая карта (самый верхний уровень)
    //1 - тактическая карта (вид на один из квадратов)
    
}
