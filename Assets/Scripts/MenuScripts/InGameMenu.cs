using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
     public static InGameMenu instance;
     public CameraController cameraController;

     [Header("Menus")]
     public GameObject shopMenu;
     public GameObject starterContextMenu;
     public GameObject starterShopMenu;
     
     [Header("Buttons")]
     public GameObject confirmationButton;
     public GameObject moveContextButtons;
     public GameObject moveContextMoveButton;
     public GameObject moveContextRotateButton;
     public Button starterContextSelectionButton;

     [Header("Colors")]
     public Color moveButtonsSelectedColor;

     [Header("Sprites")]
     public Sprite defaultStarterContextButtonSprite;
     public Sprite aluminiumStarterContextButtonSprite;
     public Sprite copperStarterContextButtonSprite;
     public Sprite goldStarterContextButtonSprite;
     public Sprite ironStarterContextButtonSprite;
     public Sprite siliconStarterContextButtonSprite;

     private BuildManager buildManager;
     private StarterShop starterShop;
     private Image moveContextMoveButtonRenderer;
     private Image moveContextRotateButtonRenderer;
     private Image starterContextSelectionButtonRenderer;
     private Color moveButtonsStartColor;
     private Starter selectedStarter;


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
          starterShop = starterShopMenu.GetComponent<StarterShop>();
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

          GameObject[] simpleDevices = GameObject.FindGameObjectsWithTag("SimpleDevice");

          foreach (var simpleDevice in simpleDevices)
          {
               simpleDevice.GetComponent<SimpleDevice>().CorrectWorkingState();
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
     public void OpenStarterContextMenu(Starter starter)
     {
          selectedStarter = starter;
          cameraController.canScroll = false;
          starterContextMenu.SetActive(true);
          UpdateStarterContextMenu();
     }
     public void CloseStarterContextMenu()
     {
          cameraController.canScroll = true;
          starterContextMenu.SetActive(false);
          selectedStarter = null;
     }
     public void OpenStarterShopMenu()
     {
          starterContextMenu.SetActive(false);
          starterShopMenu.SetActive(true);
          starterShop.starter = selectedStarter;
     }
     public void CloseStarterShopMenu()
     {
          starterShopMenu.SetActive(false);
          starterContextMenu.SetActive(true);
          UpdateStarterContextMenu();
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

     private void UpdateStarterContextMenu()
     {
          if (starterContextSelectionButtonRenderer == null)
               starterContextSelectionButtonRenderer = starterContextSelectionButton.GetComponent<Image>();

          switch (selectedStarter.prefabID)
          {
               case 1:
                    starterContextSelectionButtonRenderer.sprite = aluminiumStarterContextButtonSprite;
                    break;
               case 2:
                    starterContextSelectionButtonRenderer.sprite = copperStarterContextButtonSprite;
                    break;
               case 3:
                    starterContextSelectionButtonRenderer.sprite = goldStarterContextButtonSprite;
                    break;
               case 4:
                    starterContextSelectionButtonRenderer.sprite = ironStarterContextButtonSprite;
                    break;
               case 5:
                    starterContextSelectionButtonRenderer.sprite = siliconStarterContextButtonSprite;
                    break;
               default:
                    starterContextSelectionButtonRenderer.sprite = defaultStarterContextButtonSprite;
                    break;
          }
     }
}
