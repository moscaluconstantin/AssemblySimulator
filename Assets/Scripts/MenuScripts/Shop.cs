using UnityEngine;

public class Shop : MonoBehaviour
{
     #region DeviceBlueprints
     public DeviceBlueprint starter;
     public DeviceBlueprint roller;
     public DeviceBlueprint seller;
     public DeviceBlueprint wireDrawer;
     public DeviceBlueprint hydraulicPress;
     public DeviceBlueprint splitter;
     public DeviceBlueprint leftSplitter;
     public DeviceBlueprint rightSplitter;
     public DeviceBlueprint threeWaySplitter;
     public DeviceBlueprint crafter;
     #endregion

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
     public void SelectHydraulicPress()
     {
          buildManager.SelectDeviceToBuild(hydraulicPress);
          SelectMenuImpact();
     }
     public void SelectSplitter()
     {
          buildManager.SelectDeviceToBuild(splitter);
          SelectMenuImpact();
     }
     public void SelectLeftSplitter()
     {
          buildManager.SelectDeviceToBuild(leftSplitter);
          SelectMenuImpact();
     }
     public void SelectRightSplitter()
     {
          buildManager.SelectDeviceToBuild(rightSplitter);
          SelectMenuImpact();
     }
     public void Select3WaySplitter()
     {
          buildManager.SelectDeviceToBuild(threeWaySplitter);
          SelectMenuImpact();
     }
     public void SelectCrafter()
     {
          buildManager.SelectDeviceToBuild(crafter);
          SelectMenuImpact();
     }
}
