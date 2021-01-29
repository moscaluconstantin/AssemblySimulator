using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
     public static InGameMenu instance;

     public GameObject shopMenu;
     public GameObject confirmationButton;

     BuildManager buildManager;

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
          shopMenu.SetActive(true);
     }
     public void CloseShopMenu()
     {
          shopMenu.SetActive(false);
     }
     public void SellButtonAction()
     {
          Pointer.state = PointerState.Sell;
          OpenContextMenu();
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
          
          CloseContextMenu();
     }
     public void UpdateContextMenuText()
     {
          
     }
}
