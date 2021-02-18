using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
     public DeviceBlueprint starter;
     public DeviceBlueprint roller;
     public DeviceBlueprint seller;
     public DeviceBlueprint wireDrawer;

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
     public void SelectWireDrawer()
     {
          buildManager.SelectDeviceToBuild(wireDrawer);
          SelectMenuImpact();
     }
     public void SelectSplitter()
     {
          //buildManager.SelectDeviceToBuild(seller);
          SelectMenuImpact();
          Debug.Log("Splitter selected.");
     }
     public void SelectLeftSplitter()
     {
          //buildManager.SelectDeviceToBuild(seller);
          SelectMenuImpact();
          Debug.Log("Left Splitter selected.");
     }
     public void SelectRightSplitter()
     {
          //buildManager.SelectDeviceToBuild(seller);
          SelectMenuImpact();
          Debug.Log("Right Splitter selected.");
     }
     public void Select3WaySplitter()
     {
          //buildManager.SelectDeviceToBuild(seller);
          SelectMenuImpact();
          Debug.Log("3-Way Splitter selected.");
     }
}
