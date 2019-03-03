using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SinglePlant : MonoBehaviour {


    public Plant singlePlant;
    public static SinglePlant _Instance;
    public SingleDrone singleDrone;
    private void Awake()
    {
        _Instance = this;
        
    }

    
    public void AssignDroneToPlant(Button plant)
    {
        plant.GetComponent<Button>().image.sprite = UIManager.Instance.AssignedDroneSprite;
     
    }


    public void ShowDataForSelectedPlantInUIManager()
    {
        PlantUIManager._Instance.UpdateUIData(singlePlant);    
    }

    // setting the drone to selected plant from the PlantUIManager called OnTap on Drone button above the plant button
    public void SetDroneForSelectedPlant(Button selectedDrone)
    {
        Drone._Instance.ActivateDrneOnPlant(singlePlant,selectedDrone);
    }

  public void AssignDroneToStartWorkingOnPlant()
    {
        var drone = singleDrone;
        singleDrone.DroneID = singlePlant.PlantID;
        singleDrone.DronePlantIDAssignment = singlePlant.PlantID;
        DroneUIManager.Instance.DroneSubMenu.enabled = true;
        DroneUIManager.Instance.DroneInfo.text = "Drone assigned to work on a plant with id " + drone.DronePlantIDAssignment;


        //wait for 7 days till the drone can be removed from plant
    }
 }
