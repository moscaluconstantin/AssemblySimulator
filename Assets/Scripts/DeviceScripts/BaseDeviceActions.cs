using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDeviceActions : MonoBehaviour
{
     private Node parrentNode;
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
                    buildManager.SellDeviceFrom(parrentNode);
                    break;
               case PointerState.Rotate:
                    gameObject.transform.Rotate(new Vector3(0, 0, 90), Space.Self);
                    break;
               case PointerState.Move:
                    moveManager.AddDevice(this);
                    break;
          }
     }

     public void SetParrentNode(Node node)
     {
          parrentNode = node;
     }
     public Node GetParrentNode()
     {
          return parrentNode;
     }
}
