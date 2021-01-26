using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
     public GameObject shopMenu;

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
          shopMenu.SetActive(!shopMenu.activeSelf);
     }
}
