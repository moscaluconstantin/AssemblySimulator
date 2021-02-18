using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarterShop : MonoBehaviour
{
     [Header("Prefabs")]
     public GameObject aluminiumPrefab;
     public GameObject copperPrefab;
     public GameObject siliconPrefab;

     [Header("Optional")]
     public Starter starter;

     private InGameMenu inGameMenu;

     private void Start()
     {
          inGameMenu = InGameMenu.instance;
     }

     public void SelectNone()
     {
          SetPrefab(null);
     }
     public void SelectAluminium()
     {
          SetPrefab(aluminiumPrefab);
     }
     public void SelectCopper()
     {
          SetPrefab(copperPrefab);
     }
     public void SelectSilicon()
     {
          SetPrefab(siliconPrefab);
     }

     private void SetPrefab(GameObject prefab)
     {
          starter.SetPrefab(prefab);
          inGameMenu.CloseStarterShopMenu();
     }
}
