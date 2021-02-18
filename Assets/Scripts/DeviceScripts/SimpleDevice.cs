using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SimpleDevice : MonoBehaviour
{
     public GameObject[] prefabs;
     public GameObject generationPoint;
     public GameObject targetPoint;

     public float generationPeriod = 1f;
     public float passedTime = 0f;
     private bool isWorking;
     //private GameObject generationPrefab;

     private Queue<int> inputQueue;

     //private InGameMenu inGameMenu;

     private void Start()
     {
          CorrectWorkingState();
          //inGameMenu = InGameMenu.instance;
          //generationPrefab = null;
          inputQueue = new Queue<int>();
     }
     private void Update()
     {
          if (inputQueue.Count == 0)
               return;
          Debug.Log("queue isn't null.");
          if (!isWorking)
               return;
          Debug.Log("Device is working.");
          passedTime += Time.deltaTime;

          if (passedTime >= generationPeriod)
          {
               GenerateNewObject();
               passedTime = 0;
          }

     }
     private void OnCollisionEnter2D(Collision2D collision)
     {
          BaseObject baseObject = collision.gameObject.GetComponent<BaseObject>();
          
          if (baseObject.iD < 1 || baseObject.iD > 2)
               return;

          inputQueue.Enqueue(baseObject.iD);
          Destroy(collision.gameObject);
     }
     //private void OnMouseDown()
     //{
     //     if (EventSystem.current.IsPointerOverGameObject())
     //          return;

     //     //if (Pointer.state == PointerState.Idle)
     //     //     inGameMenu.OpenStarterContextMenu(this);
     //}

     private void GenerateNewObject()
     {
          if (inputQueue.Count == 0)
               return;
          
          int prefabID = inputQueue.Dequeue();
          GameObject newItem = prefabs[prefabID - 1];
          
          GameObject newObject = Instantiate(newItem, generationPoint.transform.position, Quaternion.identity);
          newObject.GetComponent<BaseObject>().SetTargetPosition(targetPoint.transform.position);
     }
     public void CorrectWorkingState()
     {
          isWorking = SimulationStats.Simulating;
          passedTime = 0;
     }
}
