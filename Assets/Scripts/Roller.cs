using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roller : MonoBehaviour
{
     public GameObject targetPoint;

     private void OnCollisionEnter2D(Collision2D collision)
     {
          BaseObject baseObject = collision.gameObject.GetComponent<BaseObject>();
          baseObject.SetTargetPosition(targetPoint.transform.position);
          baseObject.Revive();
     }
}
