using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObjectScript : MonoBehaviour
{
     public float price;
     public float speed;
     public float lerpDuration;

     private Vector3 lastPoint;
     private Vector3 targetPoint;
     private Vector3 tempTargetPoint;
     private float elapsedTime;

     private void Start()
     {
          elapsedTime = 0;
          lastPoint = transform.position;
          targetPoint = transform.position;
     }
     private void Update()
     {
          transform.position = Vector3.Lerp(lastPoint, targetPoint, elapsedTime / lerpDuration);

          if (transform.position == targetPoint)
          {
               lastPoint = transform.position;
               targetPoint = tempTargetPoint;
               elapsedTime = 0;
          }

          elapsedTime += Time.deltaTime;
     }

     public void SetTargetPosition(Vector3 position)
     {
          //if (targetPosition != position && tempTargetPosition == null)
          //{
          //     tempTargetPosition = position;
          //}
          //else
          //{
          //     lastPosition = transform.position;
          //     targetPosition = position;
          //     elapsedTime = 0;
          //}

          tempTargetPoint = position;
     }
     
}
