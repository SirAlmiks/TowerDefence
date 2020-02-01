using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineerTower : MonoBehaviour
{
    [Header("General")]
    public float health = 15;
    public int playerControl;

    public BoxCollider boxCollider;
    
    void Start()
    {
        boxCollider = gameObject.GetComponent<BoxCollider>();
    }

    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TurretBase") {
            other.GetComponent<InteractionControllerCells>().ownedBy = playerControl;
            if (playerControl == 1) {
                other.GetComponent<InteractionControllerCells>().rend.material.color = Color.green;
            }
            if (playerControl == 2) {
                other.GetComponent<InteractionControllerCells>().rend.material.color = Color.red;
            }
        }   
    }
}
