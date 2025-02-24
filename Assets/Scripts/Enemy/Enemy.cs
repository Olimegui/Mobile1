using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    void start()
    {
      // Para habilitar o Box Collider
      GetComponent<BoxCollider>().enabled = true;
    }
}
