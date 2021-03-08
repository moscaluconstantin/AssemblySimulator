using UnityEngine;

public class MoveManager : MonoBehaviour
{
     public static MoveManager instance;
     public Node switchNode;

     private BaseDeviceActions deviceA;
     private BaseDeviceActions deviceB;

     private void Awake()
     {
          if (instance == null)
          {
               instance = this;
               return;
          }
          Debug.Log("More than onw move manager.");
     }
     private void Start()
     {
          ResetDevices();
     }

     public void AddDevice(BaseDeviceActions device)
     {
          if (deviceA == null)
               deviceA = device;
          else
          {
               deviceB = device;
               SwitchDevices();
          }
     }
     public void AddNode(Node node)
     {
          if (deviceA == null)
               return;
          MoveDeviceToNode(deviceA, node);
          ResetDevices();
     }
     
     private void MoveDeviceToNode(BaseDeviceActions deviceBaseAction, Node node)
     {
          Node oldNode = deviceBaseAction.GetParentNode();
          
          //new node settings
          node.deviceBlueprint = oldNode.deviceBlueprint;
          node.device = oldNode.device;

          //device settings
          deviceBaseAction.SetParentNode(node);
          deviceBaseAction.gameObject.transform.position = node.gameObject.transform.position;

          //old node settings
          oldNode.deviceBlueprint = null;
          oldNode.device = null;
     }
     private void SwitchDevices()
     {
          Node deviceAOldNode = deviceA.GetComponent<BaseDeviceActions>().GetParentNode();
          Node deviceBOldNode = deviceB.GetComponent<BaseDeviceActions>().GetParentNode();
          
          MoveDeviceToNode(deviceA, switchNode);
          MoveDeviceToNode(deviceB, deviceAOldNode);
          MoveDeviceToNode(deviceA, deviceBOldNode);

          ResetDevices();
     }
     private void ResetDevices()
     {
          deviceA = null;
          deviceB = null;
     }
}
