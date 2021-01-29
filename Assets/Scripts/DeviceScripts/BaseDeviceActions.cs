using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDeviceActions : MonoBehaviour
{
     private Node parrentNode;
     private BuildManager buildManager;

     private void Start()
     {
          buildManager = BuildManager.instance;
     }
     private void OnMouseDown()
     {
          //Debug.Log("Clicked on device: " + gameObject.transform.position);
          if (Pointer.state == PointerState.Sell)
          {
               //Debug.Log("Trying to sell the device: " + gameObject.transform.position);
               buildManager.SellDeviceFrom(parrentNode);
               return;
          }
     }

     public void SetParrentNode(Node node)
     {
          parrentNode = node;
          //Debug.Log("New parrentNode: " + node.transform.position);
     }
}
