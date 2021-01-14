using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
     public Color hoverColor;

     private GameObject device;

     private Renderer rend;
     private Color startColor;

     private void Start()
     {
          rend = GetComponent<Renderer>();
          startColor = rend.material.color;
     }
     private void OnMouseEnter()
     {
          rend.material.color = hoverColor;
     }
     private void OnMouseExit()
     {
          rend.material.color = startColor;
     }
     private void OnMouseDown()
     {
          if (device != null)
          {
               Debug.Log("Can't build here.");
               return;
          }

          GameObject deviceToBuild = BuildManager.instance.GetDeviceToBuild();
          device = (GameObject)Instantiate(deviceToBuild, transform.position, Quaternion.identity);
     }
}
