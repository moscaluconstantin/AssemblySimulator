using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
     public DeviceBlueprint[] devices;

     private BuildManager buildManager;

     private void Start()
     {
          buildManager = BuildManager.instance;
     }

     public void SelectStarter()
     {
          //Debug.Log("Starter purchased.");
          foreach (var device in devices)
          {
               if (device.name == "Starter")
               {
                    buildManager.SelectDeviceToBuild(device);
                    return;
               }
          }
     }
     public void SelectRoller()
     {
          //Debug.Log("Roller purchased.");
          foreach (var device in devices)
          {
               if (device.name == "Roller")
               {
                    buildManager.SelectDeviceToBuild(device);
                    return;
               }
          }
     }
     public void SelectSeller()
     {
          //Debug.Log("Seller purchased.");
          foreach (var device in devices)
          {
               if (device.name == "Seller")
               {
                    buildManager.SelectDeviceToBuild(device);
                    return;
               }
          }
     }
}
