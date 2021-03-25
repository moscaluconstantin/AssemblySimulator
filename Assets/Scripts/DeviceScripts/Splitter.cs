using UnityEngine;
using UnityEngine.EventSystems;

public class Splitter : MonoBehaviour
{
     public SplitMode splitMode;

     #region Generation Points
     [Header("Generation Points")]
     public GameObject firstOutput;
     public GameObject secondOutput;
     public GameObject thirdOutput;
     #endregion
     #region Target Points
     [Header("Target Points")]
     public GameObject firstTargetPoint;
     public GameObject secondTargetPoint;
     public GameObject thirdTargetPoint;
     #endregion
     #region Throughput Values
     [Header("Throughput Values")]
     public int firstThroughput;
     public int secondThroughput;
     public int thirdThroughput;
     #endregion
     #region Counters
     private int firstOutputCounter;
     private int secondOutputCounter;
     private int thirdOutputCounter;
     private int outputIndx;
     #endregion

     private InGameMenu inGameMenu;

     private void Start()
     {
          inGameMenu = InGameMenu.instance;

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
               if (splitMode != SplitMode.Triple)
                    outputIndx = 1;
               else
                    outputIndx++;

               if (secondOutputCounter < secondThroughput)
               {
                    RedirectObject(collision.gameObject, secondOutput.transform.position,
                         secondTargetPoint.transform.position, ref secondOutputCounter);
                    return;
               }

               if (splitMode != SplitMode.Triple)
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
     private void OnMouseDown()
     {
          if (EventSystem.current.IsPointerOverGameObject())
               return;

          if (Pointer.state == PointerState.Idle)
               inGameMenu.OpenSplitterContextMenu(this);
     }

     public void ModifyThroughput(int throughputIndx, int value)
     {
          switch (throughputIndx)
          {
               case 1:
                    if (firstThroughput <= 1 && value < 0 || firstThroughput >= 99 && value > 0)
                         return;
                    firstThroughput += value;
                    break;
               case 2:
                    if (secondThroughput <= 1 && value < 0 || secondThroughput >= 99 && value > 0)
                         return;
                    secondThroughput += value;
                    break;
               case 3:
                    if (thirdThroughput <= 1 && value < 0 || thirdThroughput >= 99 && value > 0)
                         return;
                    thirdThroughput += value;
                    break;

               default:break;
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
