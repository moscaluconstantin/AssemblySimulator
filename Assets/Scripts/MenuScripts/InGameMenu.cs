using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
     public static InGameMenu instance;

     public CameraController cameraController;
     public GameObject shopMenu;
     public GameObject confirmationButton;
     public GameObject moveContextButtons;
     public GameObject moveContextMoveButton;
     public GameObject moveContextRotateButton;
     public Color moveButtonsSelectedColor;

     private BuildManager buildManager;
     private Image moveContextMoveButtonRenderer;
     private Image moveContextRotateButtonRenderer;
     private Color moveButtonsStartColor;

     private void Awake()
     {
          if (instance == null)
          {
               instance = this;
               return;
          }
          Debug.Log("More than one menu.");
     }

     private void Start()
     {
          buildManager = BuildManager.instance;
          moveContextMoveButtonRenderer = moveContextMoveButton.GetComponent<Image>();
          moveContextRotateButtonRenderer = moveContextRotateButton.GetComponent<Image>();
          moveButtonsStartColor = moveContextMoveButtonRenderer.material.color;
     }

     public void PlayPause()
     {
          SimulationStats.Simulating = !SimulationStats.Simulating;
          GameObject[] starters = GameObject.FindGameObjectsWithTag("Starter");
          
          foreach (var starter in starters)
          {
               starter.GetComponent<Starter>().CorrectWorkingState();
          }
     }
     public void OpenShopMenu()
     {
          Pointer.state = PointerState.Idle;
          cameraController.canScroll = false;
          shopMenu.SetActive(true);
          CloseContextMenu();
          CloseMoveContextButtons();
     }
     public void CloseShopMenu()
     {
          cameraController.canScroll = true;
          shopMenu.SetActive(false);
     }
     public void SellButtonAction()
     {
          Pointer.state = PointerState.Sell;
          OpenContextMenu();
          CloseMoveContextButtons();
     }
     public void MoveButtonAction()
     {
          Pointer.state = PointerState.Idle;
          OpenMoveContextButtons();
          OpenContextMenu();
     }
     public void MoveContextMove()
     {
          Pointer.state = PointerState.Move;
          moveContextMoveButtonRenderer.color = moveButtonsSelectedColor;
          moveContextRotateButtonRenderer.color = moveButtonsStartColor;
     }
     public void MoveContextRotate()
     {
          Pointer.state = PointerState.Rotate;
          moveContextMoveButtonRenderer.color = moveButtonsStartColor;
          moveContextRotateButtonRenderer.color = moveButtonsSelectedColor;
     }
     public void OpenMoveContextButtons()
     {
          moveContextButtons.SetActive(true);
          moveContextMoveButtonRenderer.color = moveButtonsStartColor;
          moveContextRotateButtonRenderer.color = moveButtonsStartColor;
     }
     public void CloseMoveContextButtons()
     {
          moveContextButtons.SetActive(false);
     }
     public void OpenContextMenu()
     {
          confirmationButton.SetActive(true);
     }
     public void CloseContextMenu()
     {
          confirmationButton.SetActive(false);
     }
     public void ConfirmContextMenuActions()
     {
          if (Pointer.state == PointerState.Build)
               buildManager.ClearSelectedDeviceBlueprint();

          Pointer.state = PointerState.Idle;

          CloseMoveContextButtons();
          CloseContextMenu();
     }
     public void UpdateContextMenuText()
     {
          
     }
}
