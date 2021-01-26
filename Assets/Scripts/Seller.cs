using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seller : MonoBehaviour
{
     private void OnCollisionEnter2D(Collision2D collision)
     {
          SimulationStats.Money += collision.gameObject.GetComponent<BaseObject>().price;
          Destroy(collision.gameObject);
     }
}
