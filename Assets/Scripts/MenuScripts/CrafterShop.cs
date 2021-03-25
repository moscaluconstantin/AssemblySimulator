using UnityEngine;

public class CrafterShop : MonoBehaviour
{
     [Header("Prefabs")]
     public Blueprint diodeBlueprint;
     public Blueprint galvanicBatteryBlueprint;
     public Blueprint transistorBlueprint;

     [Header("Optional")]
     public Crafter crafter;

     private InGameMenu inGameMenu;

     private void Start()
     {
          inGameMenu = InGameMenu.instance;
     }

     public void SelectNone()
     {
          SetBlueprint(null);
     }
     public void SelectDiode()
     {
          SetBlueprint(diodeBlueprint);
     }
     public void SelectGalvanicBattery()
     {
          SetBlueprint(galvanicBatteryBlueprint);
     }
     public void SelectTransistor()
     {
          SetBlueprint(transistorBlueprint);
     }

     private void SetBlueprint(Blueprint blueprint)
     {
          crafter.SetBlueprint(blueprint);
          inGameMenu.CloseCrafterShopMenu();
     }
}
