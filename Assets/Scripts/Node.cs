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

     //private GameObject nodeCovering;
     private Renderer rend;
     private Color startColor;
     public bool isSelected;

     private BuildManager buildManager;
     private MoveManager moveManager;
     private InGameMenu inGameMenu;

     private void Start()
     {
          rend = GetComponent<Renderer>();
          
          startColor = rend.material.color;

          buildManager = BuildManager.instance;
          moveManager = MoveManager.instance;
          inGameMenu = InGameMenu.instance;
          isSelected = false;
     }
     private void OnMouseDown()
     {
          if (EventSystem.current.IsPointerOverGameObject())
               return;
          
          if (device != null)
               return;
          
          if (Pointer.state == PointerState.Move)
               moveManager.AddNode(this);

          if (!buildManager.CanBuild)
               return;

          if (Pointer.state == PointerState.Build)
               buildManager.BuildDeviceOn(this);
     }
}
