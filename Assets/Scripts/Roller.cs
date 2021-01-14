using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roller : MonoBehaviour
{
     public GameObject targetPoint;

     private void OnTriggerEnter2D(Collider2D collision)
     {
          Debug.Log("Trigger entered");
          collision.gameObject.GetComponent<BaseObject>().SetTargetPosition(targetPoint.transform.position);
     }
}
