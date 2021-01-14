using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerScript : MonoBehaviour
{
     public GameObject targetPoint;

     private void OnTriggerEnter2D(Collider2D collision)
     {
          Debug.Log("Trigger entered");
          collision.gameObject.GetComponent<BaseObjectScript>().SetTargetPosition(targetPoint.transform.position);
     }
}
