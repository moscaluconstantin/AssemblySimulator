using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
     public DeviceBlueprint[] devices;

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
          foreach (var device in devices)
          {
               if (device.name == "Starter")
               {
                    buildManager.SelectDeviceToBuild(device);
                    SelectMenuImpact();
                    return;
               }
          }    
     }
     public void SelectRoller()
     {
          foreach (var device in devices)
          {
               if (device.name == "Roller")
               {
                    buildManager.SelectDeviceToBuild(device);
                    SelectMenuImpact();
                    return;
               }
          }
     }
     public void SelectSeller()
     {
          foreach (var device in devices)
          {
               if (device.name == "Seller")
               {
                    buildManager.SelectDeviceToBuild(device);
                    SelectMenuImpact();
                    return;
               }
          }
          
     }
}
