using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DeviceBlueprint
{
     public GameObject prefab;
     public string name;
     public int cost;

     public int GetSellCost()
     {
          return (int)(cost * 0.9f);
     }
}
