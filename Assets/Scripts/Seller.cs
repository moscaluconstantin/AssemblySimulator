using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seller : MonoBehaviour
{
     public float Money;

     private void Start()
     {
          Money = 0;
     }

     private void OnTriggerEnter2D(Collider2D collision)
     {
          Money += collision.gameObject.GetComponent<BaseObject>().price;
          Destroy(collision.gameObject);
     }
}
