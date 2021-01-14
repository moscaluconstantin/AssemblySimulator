using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
     public static BuildManager instance;
     public GameObject standardDeviceToBuild;
     
     private GameObject deviceToBuild;

     private void Awake()
     {
          if (instance == null)
          {
               instance = this;
               return;
          }
          Debug.Log("More than onw build manager.");
     }
     private void Start()
     {
          deviceToBuild = standardDeviceToBuild;
     }

     public GameObject GetDeviceToBuild()
     {
          return deviceToBuild;
     }
}
