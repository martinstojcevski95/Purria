using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DroneUIManager : MonoBehaviour {


    public static DroneUIManager Instance;

    public Text DroneInfo;
    public Canvas DroneSubMenu;

    private void Awake()
    {
        Instance = this;
    }

    public void CurrentlyOpenedMenu(int index)
    {
        UIManager.Instance.CurrentMenuSection = "Drones";
        UIManager.Instance.CurrentSelectedUIMenu.text = "Current Section - " + UIManager.Instance.CurrentMenuSection;
        UIManager.Instance.ManageUIMenus(index);

    }

    public void OpenDroneSubMenu()
    {
        DroneSubMenu.enabled = true;

    }
    public void CloseDroneSubMenu()
    {
        DroneSubMenu.enabled = false;
    }


    // METHOD FOR BUYING DRONES FROM THE SHOP IN THE DRONE UI MANAGER
}
