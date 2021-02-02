using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
     public DeviceBlueprint starter;
     public DeviceBlueprint roller;
     public DeviceBlueprint seller;

     private BuildManager buildManager;
     private InGameMenu inGameMenu;

     private void Start()
     {
          buildManager = BuildManager.instance;
          inGameMenu = InGameMenu.instance;
     }

     private void SelectMenuImpact()
     {
          inGameMenu.OpenContextMenu();
          inGameMenu.CloseShopMenu();
          Pointer.state = PointerState.Build;
     }

     public void SelectStarter()
     {   
          buildManager.SelectDeviceToBuild(starter);
          SelectMenuImpact();
     }
     public void SelectRoller()
     {
          buildManager.SelectDeviceToBuild(roller);
          SelectMenuImpact();
     }
     public void SelectSeller()
     {
          buildManager.SelectDeviceToBuild(seller);
          SelectMenuImpact();
     }
}
