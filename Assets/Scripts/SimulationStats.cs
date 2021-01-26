using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationStats : MonoBehaviour
{
     public static bool Simulating;
     public static int Money;
     public int MoneyPerSecond;

     private void Start()
     {
          Money = 10000;
          Simulating = false;
     }
}
