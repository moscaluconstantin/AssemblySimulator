using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimulationStats : MonoBehaviour
{
     public Text moneyText;
     public static bool Simulating;
     public static int Money;
     
     public int MoneyPerSecond;

     private void Start()
     {
          Money = 1000000;
          Simulating = false;
     }
     private void Update()
     {
          moneyText.text = Money.ToString();
     }
}
