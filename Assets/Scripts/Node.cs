using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
     public Color buildSelectColor;
     public Color sellSelectColor;

     [Header("Optional")]
     public GameObject device;

     [HideInInspector]
     public DeviceBlueprint deviceBlueprint;

     private Renderer rend;
     private Color startColor;
     private bool isSelected;

     private BuildManager buildManager;

     private void Start()
     {
          rend = GetComponent<Renderer>();
          startColor = rend.material.color;
          buildManager = BuildManager.instance;
          isSelected = false;
     }
     //private void OnMouseEnter()
     //{
     //     if (EventSystem.current.IsPointerOverGameObject())
     //          return;

     //     if (!buildManager.CanBuild)
     //          return;

     //     rend.material.color = hoverColor;
     //}
     //private void OnMouseExit()
     //{
     //     rend.material.color = startColor;
     //}
     private void OnMouseDown()
     {
          if (EventSystem.current.IsPointerOverGameObject())
               return;

          //if (!buildManager.CanBuild)
          //     return;

          //if (device != null)
          //{
          //     Debug.Log("Can't build here.");
          //     return;
          //}

          //buildManager.BuildDeviceOn(this);

          if (!isSelected)
          {
               switch (Pointer.state)
               {
                    case PointerState.Build:
                         rend.material.color = buildSelectColor;
                         break;
                    case PointerState.Sell:
                         rend.material.color = sellSelectColor;
                         break;
               }
               buildManager.AddNodeToList(this);
               isSelected = true;
          }
          else
          {
               rend.material.color = startColor;
               buildManager.RemoveNodeFromList(this);
               isSelected = false;
          }
     }

     
}
