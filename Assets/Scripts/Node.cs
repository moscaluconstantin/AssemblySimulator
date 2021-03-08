using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
     [Header("Optional")]
     public GameObject device;

     [HideInInspector]
     public DeviceBlueprint deviceBlueprint;

     private BuildManager buildManager;
     private MoveManager moveManager;

     private void Start()
     {
          buildManager = BuildManager.instance;
          moveManager = MoveManager.instance;
     }
     private void OnMouseDown()
     {
          if (EventSystem.current.IsPointerOverGameObject())
               return;
          
          if (device != null)
               return;
          
          if (Pointer.state == PointerState.Move)
               moveManager.AddNode(this);

          if (!buildManager.CanBuild)
               return;

          if (Pointer.state == PointerState.Build)
               buildManager.BuildDeviceOn(this);
     }
}
