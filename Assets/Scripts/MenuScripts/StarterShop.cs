using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarterShop : MonoBehaviour
{
     [Header("Prefabs")]
     public GameObject aluminiumRockPrefab;
     public GameObject copperRockPrefab;
     public GameObject goldenRockPrefab;
     public GameObject ironRockPrefab;
     public GameObject siliconRockPrefab;

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
          SetPrefab(aluminiumRockPrefab);
     }
     public void SelectCopper()
     {
          SetPrefab(copperRockPrefab);
     }
     public void SelectGold()
     {
          SetPrefab(goldenRockPrefab);
     }
     public void SelectIron()
     {
          SetPrefab(ironRockPrefab);
     }
     public void SelectSilicon()
     {
          SetPrefab(siliconRockPrefab);
     }

     private void SetPrefab(GameObject prefab)
     {
          starter.SetPrefab(prefab);
          inGameMenu.CloseStarterShopMenu();
     }
}
