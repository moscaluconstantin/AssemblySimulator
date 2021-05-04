using UnityEngine;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
     public static InGameMenu instance;
     public CameraController cameraController;

     #region Menus
     [Header("Menus")]
     public GameObject shopMenu;
     public GameObject starterContextMenu;
     public GameObject starterShopMenu;
     public GameObject splitterContextMenu;
     public GameObject crafterContextMenu;
     public GameObject crafterShopMenu;
     #endregion
     #region Buttons
     [Header("Buttons")]
     public GameObject confirmationButton;
     public GameObject moveContextButtons;
     public GameObject moveContextMoveButton;
     public GameObject moveContextRotateButton;
     public Button starterContextSelectionButton;
     public GameObject leftSplitterContextMenuButtons;
     public GameObject centerSplitterContextMenuButtons;
     public GameObject rightSplitterContextMenuButtons;
     #endregion
     #region TextBoxes
     [Header("TextBoxes")]
     public Text leftSplitterContextMenuText;
     public Text centerSplitterContextMenuText;
     public Text rightSplitterContextMenuText;
     public Text playButtonText;
     public Text crafterContextMenuBlueprintText;
     #endregion
     #region Sprites
     [Header("Colors")]
     public Color moveButtonsSelectedColor;

     [Header("Sprites")]
     public Sprite defaultStarterContextButtonSprite;
     public Sprite aluminiumStarterContextButtonSprite;
     public Sprite copperStarterContextButtonSprite;
     public Sprite goldStarterContextButtonSprite;
     public Sprite ironStarterContextButtonSprite;
     public Sprite siliconStarterContextButtonSprite;
     #endregion
     #region Privates
     private BuildManager buildManager;
     private StarterShop starterShop;
     private CrafterShop crafterShop;
     private Image moveContextMoveButtonRenderer;
     private Image moveContextRotateButtonRenderer;
     private Image starterContextSelectionButtonRenderer;
     private Color moveButtonsStartColor;
     private Starter selectedStarter;
     private Splitter selectedSplitter;
     private Crafter selectedCrafter;
     #endregion

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
          crafterShop = crafterShopMenu.GetComponent<CrafterShop>();
          moveContextMoveButtonRenderer = moveContextMoveButton.GetComponent<Image>();
          moveContextRotateButtonRenderer = moveContextRotateButton.GetComponent<Image>();
          moveButtonsStartColor = moveContextMoveButtonRenderer.material.color;
     }

     //Basic InGameMenu methods
     public void PlayPause()
     {
          if (SimulationStats.Simulating)
          {
               SimulationStats.Simulating = false;
               playButtonText.text = "Play";
          }
          else
          {
               SimulationStats.Simulating = true;
               playButtonText.text = "Pause";
          }
          
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

          GameObject[] crafters = GameObject.FindGameObjectsWithTag("Crafter");
          foreach (var crafter in crafters)
          {
               crafter.GetComponent<Crafter>().CorrectWorkingState();
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
     public void ExitButtonAction()
     {
          Application.Quit();
     }

     #region  Basic context menu methods
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
     #endregion
     #region Move context menu methods
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
     #endregion
     #region Starter context menu methods
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
     #endregion
     #region Splitter context menu methods
     public void OpenSplitterContextMenu(Splitter splitter)
     {
          selectedSplitter = splitter;
          splitterContextMenu.SetActive(true);
          UpdateSplitterContextMenuButtons();
          UpdateSplitterContextMenuText();
     }
     public void CloseSplitterContextMenu()
     {
          selectedSplitter = null;
          splitterContextMenu.SetActive(false);
     }
     public void ModifyLeftSplitterContextMenuText(int value)
     {
          selectedSplitter.ModifyThroughput(1, value);
          UpdateSplitterContextMenuText();
     }
     public void ModifyRightSplitterContextMenuText(int value)
     {
          if (selectedSplitter.splitMode == SplitMode.Right)
               selectedSplitter.ModifyThroughput(1, value);
          else
               selectedSplitter.ModifyThroughput(2, value);

          UpdateSplitterContextMenuText();
     }
     public void ModifyCenterSplitterContextMenuText(int value)
     {
          if (selectedSplitter.splitMode == SplitMode.Triple)
               selectedSplitter.ModifyThroughput(3, value);
          else
               selectedSplitter.ModifyThroughput(2, value);

          UpdateSplitterContextMenuText();
     }
     private void UpdateSplitterContextMenuButtons()
     {
          leftSplitterContextMenuButtons.SetActive(true);
          centerSplitterContextMenuButtons.SetActive(true);
          rightSplitterContextMenuButtons.SetActive(true);

          switch (selectedSplitter.splitMode)
          {
               case SplitMode.Simple:
                    centerSplitterContextMenuButtons.SetActive(false);
                    break;
               case SplitMode.Left:
                    rightSplitterContextMenuButtons.SetActive(false);
                    break;
               case SplitMode.Right:
                    leftSplitterContextMenuButtons.SetActive(false);
                    break;

               default: break;
          }
     }
     private void UpdateSplitterContextMenuText()
     {
          switch (selectedSplitter.splitMode)
          {
               case SplitMode.Simple:
                    leftSplitterContextMenuText.text = selectedSplitter.firstThroughput.ToString();
                    rightSplitterContextMenuText.text = selectedSplitter.secondThroughput.ToString();
                    break;
               case SplitMode.Left:
                    leftSplitterContextMenuText.text = selectedSplitter.firstThroughput.ToString();
                    centerSplitterContextMenuText.text = selectedSplitter.secondThroughput.ToString();
                    break;
               case SplitMode.Right:
                    rightSplitterContextMenuText.text = selectedSplitter.firstThroughput.ToString();
                    centerSplitterContextMenuText.text = selectedSplitter.secondThroughput.ToString();
                    break;
               case SplitMode.Triple:
                    leftSplitterContextMenuText.text = selectedSplitter.firstThroughput.ToString();
                    rightSplitterContextMenuText.text = selectedSplitter.secondThroughput.ToString();
                    centerSplitterContextMenuText.text = selectedSplitter.thirdThroughput.ToString();
                    break;

               default: break;
          }
     }
     #endregion
     #region Crafter context menu methods
     public void OpenCrafterContextMenu(Crafter crafter)
     {
          cameraController.canScroll = false;
          selectedCrafter = crafter;
          crafterContextMenu.SetActive(true);
          UpdateCrafterContextMenu();
     }
     public void CloseCrafterContextMenu()
     {
          cameraController.canScroll = true;
          selectedCrafter = null;
          crafterContextMenu.SetActive(false);
     }
     public void OpenCrafterShopMenu()
     {
          crafterContextMenu.SetActive(false);
          crafterShopMenu.SetActive(true);
          crafterShop.crafter = selectedCrafter;
     }
     public void CloseCrafterShopMenu()
     {
          crafterContextMenu.SetActive(true);
          crafterShopMenu.SetActive(false);
          UpdateCrafterContextMenu();
     }
     private void UpdateCrafterContextMenu()
     {
          if (selectedCrafter.blueprint != null)
               crafterContextMenuBlueprintText.text = selectedCrafter.blueprint.name;
          else
               crafterContextMenuBlueprintText.text = "None";
     }
     #endregion
}
