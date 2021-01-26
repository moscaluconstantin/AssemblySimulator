using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
     public static BuildManager instance;
     public GameObject starterPrefab;
     public GameObject rollerPrefab;
     public GameObject sellerPrefab;

     private DeviceBlueprint deviceToBuild;

     public bool CanBuild { get { return deviceToBuild != null; } }

     private void Awake()
     {
          if (instance == null)
          {
               instance = this;
               return;
          }
          Debug.Log("More than onw build manager.");
     }
     
     public void SelectDeviceToBuild(DeviceBlueprint device)
     {
          deviceToBuild = device;
     }
     public GameObject GetDeviceToBuild()
     {
          return deviceToBuild.prefab;
     }
     public void BuildDeviceOn(Node node)
     {
          if (SimulationStats.Money < deviceToBuild.cost)
               return;

          SimulationStats.Money -= deviceToBuild.cost;

          node.device = (GameObject)Instantiate(deviceToBuild.prefab, node.transform.position, Quaternion.identity);
     }
}
