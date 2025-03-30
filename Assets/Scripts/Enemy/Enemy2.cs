using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    void start()
    {
        // Para habilitar o Box Collider
        GetComponent<CapsuleCollider>().enabled = true;
    }
}
