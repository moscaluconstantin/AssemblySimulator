using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellerScript : MonoBehaviour
{
     public float Money;

     private void Start()
     {
          Money = 0;
     }

     private void OnTriggerEnter2D(Collider2D collision)
     {
          Money += collision.gameObject.GetComponent<BaseObjectScript>().price;
          Destroy(collision.gameObject);
     }
}
