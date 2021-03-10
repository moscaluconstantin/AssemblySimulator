using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Splitter : MonoBehaviour
{
     public SplitMode splitMode;

     [Header("Generation Points")]
     public GameObject firstOutput;
     public GameObject secondOutput;
     public GameObject thirdOutput;

     [Header("Target Points")]
     public GameObject firstTargetPoint;
     public GameObject secondTargetPoint;
     public GameObject thirdTargetPoint;

     [Header("Throughput Values")]
     public int firstThroughput;
     public int secondThroughput;
     public int thirdThroughput;

     private int firstOutputCounter;
     private int secondOutputCounter;
     private int thirdOutputCounter;
     private int outputIndx;

     private void Start()
     {
          firstThroughput = 1;
          secondThroughput = 1;
          thirdThroughput = 1;
          outputIndx = 1;

          ClearOutputCounters();
     }
     private void OnCollisionEnter2D(Collision2D collision)
     {
          GameObject tempObject = collision.gameObject;
          BaseObject baseObject = tempObject.GetComponent<BaseObject>();

          if (outputIndx == 1)
          {
               outputIndx++;
               if (firstOutputCounter < firstThroughput)
               {
                    RedirectObject(collision.gameObject, firstOutput.transform.position,
                         firstTargetPoint.transform.position, ref firstOutputCounter);
                    return;
               }
          }
          if (outputIndx == 2)
          {
               if (splitMode == SplitMode.Double)
                    outputIndx = 1;
               else
                    outputIndx++;

               if (secondOutputCounter < secondThroughput)
               {
                    RedirectObject(collision.gameObject, secondOutput.transform.position,
                         secondTargetPoint.transform.position, ref secondOutputCounter);
                    return;
               }

               if (splitMode == SplitMode.Double)
               {
                    ClearOutputCounters();
                    return;
               }
          }
          if (outputIndx == 3)
          {
               outputIndx = 1;
               if (thirdOutputCounter < thirdThroughput)
               {
                    RedirectObject(collision.gameObject, thirdOutput.transform.position,
                         thirdTargetPoint.transform.position, ref thirdOutputCounter);
                    return;
               }
               ClearOutputCounters();
          }
     }

     private void RedirectObject(GameObject gameObject, Vector3 output, Vector3 targetPosition, ref int outputCounter)
     {
          gameObject.transform.position = output;
          gameObject.GetComponent<BaseObject>().SetTargetPosition(targetPosition);
          outputCounter++;
     }
     private void ClearOutputCounters()
     {
          firstOutputCounter = 0;
          secondOutputCounter = 0;
          thirdOutputCounter = 0;
     }
}
