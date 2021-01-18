using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{
     public GameObject prefab;
     public GameObject generationPoint;
     public GameObject targetPoint;
     public int elementsPerSecond;

     public float generationPeriod = 1f;
     private float passedTime = 0f;

     private void Update()
     {
          passedTime += Time.deltaTime;

          if (passedTime >= generationPeriod)
          {
               GenerateNewObject();
               passedTime = 0;
          }

     }

     private void GenerateNewObject()
     {
          GameObject newObject = Instantiate(prefab, generationPoint.transform.position, Quaternion.identity);
          newObject.GetComponent<BaseObject>().SetTargetPosition(targetPoint.transform.position);
     }
}
