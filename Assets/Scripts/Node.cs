using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
     public Color hoverColor;

     [Header("Optional")]
     public GameObject device;

     private Renderer rend;
     private Color startColor;

     private BuildManager buildManager;

     private void Start()
     {
          rend = GetComponent<Renderer>();
          startColor = rend.material.color;
          buildManager = BuildManager.instance;
     }
     private void OnMouseEnter()
     {
          if (EventSystem.current.IsPointerOverGameObject())
               return;

          if (!buildManager.CanBuild)
               return;

          rend.material.color = hoverColor;
     }
     private void OnMouseExit()
     {
          rend.material.color = startColor;
     }
     private void OnMouseDown()
     {
          if (EventSystem.current.IsPointerOverGameObject())
               return;

          if (!buildManager.CanBuild)
               return;

          if (device != null)
          {
               Debug.Log("Can't build here.");
               return;
          }

          buildManager.BuildDeviceOn(this);
     }
}
