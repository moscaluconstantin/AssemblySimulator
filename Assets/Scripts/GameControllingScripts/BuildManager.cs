using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
     public static BuildManager instance;
     public string blueprintName;

     private DeviceBlueprint deviceToBuild;
     //public List<Node> selectedNodes;

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
          blueprintName = device.name;
     }
     public DeviceBlueprint GetDeviceToBuild()
     {
          return deviceToBuild;
     }
     public void BuildDeviceOn(Node node)
     {
          if (SimulationStats.Money < deviceToBuild.cost)
               return;

          SimulationStats.Money -= deviceToBuild.cost;

          node.deviceBlueprint = deviceToBuild;
          node.device = (GameObject)Instantiate(deviceToBuild.prefab, node.transform.position, Quaternion.identity);
          node.device.GetComponent<BaseDeviceActions>().SetParrentNode(node);
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
          blueprintName = "";
     }
     //public void AddNodeToList(Node node)
     //{
     //     selectedNodes.Add(node);
     //}
     //public void RemoveNodeFromList(Node node)
     //{
     //     selectedNodes.Remove(node);
     //}
     //public void ClearNodesList()
     //{
     //     foreach (Node node in selectedNodes)
     //     {
     //          node.isSelected = false;
     //          node.SetNodeCoveringToIdleState();
     //     }
     //     selectedNodes.Clear();
     //}
     //public void BuildOnSelectedNodes()
     //{
     //     foreach (Node node in selectedNodes)
     //     {
     //          BuildDeviceOn(node);
     //     }
     //     ClearNodesList();
     //}
}
