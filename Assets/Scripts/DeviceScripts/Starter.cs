using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Starter : MonoBehaviour
{
     public GameObject generationPoint;
     public GameObject targetPoint;
     public int elementsPerSecond;
     public int prefabID { get { return generationPrefabID; } }

     public float generationPeriod = 1f;
     private float passedTime = 0f;
     private bool isWorking;
     private GameObject generationPrefab;
     private int generationPrefabID;

     private InGameMenu inGameMenu;

     private void Start()
     {
          CorrectWorkingState();
          inGameMenu = InGameMenu.instance;
          generationPrefab = null;
          generationPrefabID = 0;
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
     private void OnMouseDown()
     {
          if (EventSystem.current.IsPointerOverGameObject())
               return;

          if (Pointer.state == PointerState.Idle)
               inGameMenu.OpenStarterContextMenu(this);
     }

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
     public void SetPrefab(GameObject prefab)
     {
          generationPrefab = prefab;
          if (prefab == null)
               generationPrefabID = 0;
          else
               generationPrefabID = generationPrefab.GetComponent<BaseObject>().iD;
     }
}
