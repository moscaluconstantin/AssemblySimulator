using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
     public static PointerState state;

     private void Start()
     {
          state = PointerState.Idle;
     }
     
}
