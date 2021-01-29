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
     private InGameMenu inGameMenu;

     private void Start()
     {
          rend = GetComponent<Renderer>();
          
          startColor = rend.material.color;
          //nodeCovering.SetActive(false);

          buildManager = BuildManager.instance;
          inGameMenu = InGameMenu.instance;
          isSelected = false;
     }
     private void OnMouseDown()
     {
          if (EventSystem.current.IsPointerOverGameObject())
               return;

          if (!buildManager.CanBuild)
               return;

          if (device != null)
               return;

          if (Pointer.state == PointerState.Build)
               buildManager.BuildDeviceOn(this);
     }
     //private void OnMouseEnter()
     //{
     //     if (EventSystem.current.IsPointerOverGameObject())
     //          return;

          
     //}

     //public void SetNodeCoveringToIdleState()
     //{
     //     rend.material.color = startColor;
     //     nodeCovering.SetActive(false);
     //}
     //public void SelectThisNode()
     //{
     //     if (isSelected)
     //          return;

     //     int selectedPrice = 0;

     //     switch (Pointer.state)
     //     {
     //          case PointerState.Build:
     //               nodeCovering.SetActive(true);
     //               rend.material.color = buildSelectColor;

     //               selectedPrice = -buildManager.GetDeviceToBuild().cost;
     //               break;
     //          case PointerState.Sell:
     //               nodeCovering.SetActive(true);
     //               rend.material.color = sellSelectColor;

     //               selectedPrice = deviceBlueprint.cost;
     //               break;
     //     }
     //     buildManager.AddNodeToList(this);
     //     SimulationStats.SelectedValue += selectedPrice;
     //     inGameMenu.UpdateContextMenuText();
     //     isSelected = true;
     //}
     //public void UnselectThisNode()
     //{
     //     if (!isSelected)
     //          return;

     //     int selectedPrice = 0;

     //     switch (Pointer.state)
     //     {
     //          case PointerState.Build:
     //               //rend.material.color = buildSelectColor;
     //               selectedPrice = buildManager.GetDeviceToBuild().cost;
     //               inGameMenu.UpdateContextMenuText();
     //               break;
     //          case PointerState.Sell:
     //               //rend.material.color = sellSelectColor;
     //               selectedPrice = -deviceBlueprint.cost;
     //               break;
     //     }
     //     SetNodeCoveringToIdleState();
     //     buildManager.RemoveNodeFromList(this);
     //     SimulationStats.SelectedValue -= selectedPrice;
     //     inGameMenu.UpdateContextMenuText();
     //     isSelected = false;
     //}
}
