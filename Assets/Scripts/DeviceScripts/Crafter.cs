using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Crafter : MonoBehaviour
{
     public GameObject generationPoint;
     public GameObject targetPoint;
     public float generationPeriod = 1f;
     public Blueprint blueprint;

     private Dictionary<int, int> objectList;
     private float passedTime = 0f;
     private bool isWorking;
     public bool isCrafting;

     private InGameMenu inGameMenu;

     private void Start()
     {
          CorrectWorkingState();
          inGameMenu = InGameMenu.instance;
          objectList = new Dictionary<int, int>();
          isCrafting = false;
     }
     private void Update()
     {
          if (blueprint == null)
               return;

          if (!isWorking)
               return;

          if (!isCrafting && CanCreate())
               isCrafting = true;

          if(isCrafting && passedTime < generationPeriod)
          {
               passedTime += Time.deltaTime;
          }else if(isCrafting && passedTime >= generationPeriod)
          {
               Craft();
               isCrafting = false;
               passedTime = 0;
          }
     }
     private void OnCollisionEnter2D(Collision2D collision)
     {
          BaseObject baseObject = collision.gameObject.GetComponent<BaseObject>();

          if (objectList.ContainsKey(baseObject.iD))
               objectList[baseObject.iD]++;
          else
               objectList.Add(baseObject.iD, 1);

          Destroy(collision.gameObject);
     }
     private void OnMouseDown()
     {
          if (EventSystem.current.IsPointerOverGameObject())
               return;


          if (Pointer.state == PointerState.Idle)
               inGameMenu.OpenCrafterContextMenu(this);
     }

     public void SetBlueprint(Blueprint blueprint)
     {
          if (blueprint == null)
          {
               ClearBlueprint();
               return;
          }

          this.blueprint = blueprint;
     }
     public void ClearBlueprint()
     {
          blueprint = null;
     }
     private void Craft()
     {
          foreach (var item in blueprint.blueprintItems)
          {
               objectList[item.ID] -= item.Quantity;
          }

          GameObject newObject = (GameObject)Instantiate(blueprint.prefab, generationPoint.transform.position, Quaternion.identity);
          newObject.GetComponent<BaseObject>().SetTargetPosition(targetPoint.transform.position);
     }
     public void CorrectWorkingState()
     {
          isWorking = SimulationStats.Simulating;
          passedTime = 0;
     }

     private bool CanCreate()
     {
          bool response = true;
          foreach (var item in blueprint.blueprintItems)
          {
               if (objectList.ContainsKey(item.ID))
               {
                    if (objectList[item.ID] >= item.Quantity)
                         response = response && true;
                    else
                         response = response && false;
               }
               else
               {
                    response = response && false;
               }
          }

          return response;
     }
}
