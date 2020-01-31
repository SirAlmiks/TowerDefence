using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public GameObject enemy; //тип появляющегося врага
    public int count; //количество врагов
    public float rate;  //пауза между появлением врагов
}
