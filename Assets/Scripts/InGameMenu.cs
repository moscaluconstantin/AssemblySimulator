using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
     public static InGameMenu instance;

     public GameObject shopMenu;
     public GameObject shopContextMenu;

     private void Awake()
     {
          if (instance == null)
          {
               instance = this;
               return;
          }
          Debug.Log("More than one menu.");
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
     public void OpenShopContextMenu()
     {
          shopContextMenu.SetActive(true);
     }
     public void CloseShopContextMenu()
     {
          shopContextMenu.SetActive(false);
     }
     public void ConfirmShopMenuActions()
     {
          Pointer.state = PointerState.Idle;
          BuildManager.instance.BuildOnSelectedNodes();
          CloseShopContextMenu();
     }
     public void DiscardShopMenuActions()
     {
          Pointer.state = PointerState.Idle;
          BuildManager.instance.ClearNodesList();
          CloseShopContextMenu();
     }
}
