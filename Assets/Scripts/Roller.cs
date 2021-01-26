using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roller : MonoBehaviour
{
     public GameObject targetPoint;

     private void OnCollisionEnter2D(Collision2D collision)
     {
          collision.gameObject.GetComponent<BaseObject>().SetTargetPosition(targetPoint.transform.position);
     }
}
