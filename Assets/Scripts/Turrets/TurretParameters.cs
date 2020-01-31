using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretParameters : MonoBehaviour
{   
    [Header("General")]
    public float range = 2f; //Дальность обзора башни
    public Transform target; //Определение цели
    public Enemy targetEnemy;

    [Header("Use Bullets (default)")]
    public float fireRate = 1f; //скорость стрельбы
    public float fireCountdown = 0f; //откат после стрельбы (равно скорости стрельбы)

    [Header("Use Laser")]
    public bool useLaser = false;
    public LineRenderer lineRenderer;
    public float damageOverTime = 1; //урон со временем
    public float slowPrc = .3f; //замедление в процентах
    
}
