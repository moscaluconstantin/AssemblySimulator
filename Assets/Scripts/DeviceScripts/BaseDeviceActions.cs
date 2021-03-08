using UnityEngine;

public class BaseDeviceActions : MonoBehaviour
{
     private Node parentNode;
     private BuildManager buildManager;
     private MoveManager moveManager;

     private void Start()
     {
          buildManager = BuildManager.instance;
          moveManager = MoveManager.instance;
     }
     private void OnMouseDown()
     {
          switch (Pointer.state)
          {
               case PointerState.Sell:
                    buildManager.SellDeviceFrom(parentNode);
                    break;
               case PointerState.Rotate:
                    gameObject.transform.Rotate(new Vector3(0, 0, 90), Space.Self);
                    break;
               case PointerState.Move:
                    moveManager.AddDevice(this);
                    break;
          }
     }

     public void SetParentNode(Node node)
     {
          parentNode = node;
     }
     public Node GetParentNode()
     {
          return parentNode;
     }
}
