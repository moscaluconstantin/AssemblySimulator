using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationStats : MonoBehaviour
{
     public static bool Simulating;
     public static int Money;
     public static int SelectedValue;
     public int MoneyPerSecond;

     private void Start()
     {
          Money = 10000;
          SelectedValue = 0;
          Simulating = false;
     }
}
