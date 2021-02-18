using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SimpleDeviceScript : MonoBehaviour
{
     public GameObject[] prefabs;
     public GameObject generationPoint;
     public GameObject targetPoint;

     public float generationPeriod = 1f;
     private float passedTime = 0f;
     private bool isWorking;
     private GameObject generationPrefab;

     private Queue<int> inputQueue;

     //private InGameMenu inGameMenu;

     private void Start()
     {
          CorrectWorkingState();
          //inGameMenu = InGameMenu.instance;
          generationPrefab = null;
          inputQueue = new Queue<int>();
     }
     private void Update()
     {
          if (generationPrefab == null)
               return;

          if (!isWorking)
               return;

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
          if (baseObject.iD == 1 || baseObject.iD == 2)
          {
               inputQueue.Enqueue(baseObject.iD);
               Debug.Log("Total: " + inputQueue.Count + "; New: " + baseObject.iD);
          }
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
          GameObject newObject = Instantiate(generationPrefab, generationPoint.transform.position, Quaternion.identity);
          newObject.GetComponent<BaseObject>().SetTargetPosition(targetPoint.transform.position);
     }
     public void CorrectWorkingState()
     {
          isWorking = SimulationStats.Simulating;
          passedTime = 0;
     }
}
