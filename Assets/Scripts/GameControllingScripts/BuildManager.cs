using UnityEngine;

public class BuildManager : MonoBehaviour
{
     public static BuildManager instance;

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
     public void BuildDeviceOn(Node node)
     {
          if (SimulationStats.Money < deviceToBuild.cost)
               return;

          SimulationStats.Money -= deviceToBuild.cost;

          node.deviceBlueprint = deviceToBuild;
          node.device = (GameObject)Instantiate(deviceToBuild.prefab, node.transform.position, Quaternion.identity);
          node.device.GetComponent<BaseDeviceActions>().SetParentNode(node);
     }
     public void SellDeviceFrom(Node node)
     {
          SimulationStats.Money += node.deviceBlueprint.cost;

          node.deviceBlueprint = null;
          Destroy(node.device);
     }
     public void ClearSelectedDeviceBlueprint()
     {
          deviceToBuild = null;
     }
}
