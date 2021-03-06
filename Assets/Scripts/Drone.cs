﻿using Firebase.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drone : MonoBehaviour
{
    int TempPlantID;
    DateTime currentDate;
    public static string USERID;
    public static Drone _Instance;

    private static System.DateTime startDate;
    private static System.DateTime today;


    private void Awake()
    {
        _Instance = this;
        USERID = PlayerPrefs.GetString("ID");
    
        droneUiManager = (DroneUIManager)FindObjectOfType(typeof(DroneUIManager));

    }

    private void Start()
    {
        SetStartDate();
       // drone.DroneStartedWorkingTime = startDate;

    }

    //Drone work for assigned plant
    public void ActivateDrneOnPlant(Plant selectedPlant, Button selectedUIDrone)
    {
        
        TempPlantID = selectedPlant.PlantID;
        currentDate = DateTime.Now;
        PopulatePlantData(selectedPlant, "Plants", TempPlantID, currentDate);
      //  selectedUIDrone.GetComponent<Image>().color = Color.green;
        selectedUIDrone.transform.parent.GetComponent<Button>().GetComponentInChildren<Text>().text = "PlantID " + TempPlantID;
        //ASSIGN 3D MODEL OF THE DRONE TO THE HEXAGON FIELD WHEN A DRONE IS PLACED IN THE 
       

   

       // GetDaysPassed();
    }



    void SetStartDate()
    {
        if (PlayerPrefs.HasKey("DateInitialized")) //if we have the start date saved, we'll use that
            startDate = System.Convert.ToDateTime(PlayerPrefs.GetString("DateInitialized"));
        else //otherwise...
        {
            startDate = System.DateTime.Now; //save the start date ->
            PlayerPrefs.SetString("DateInitialized", startDate.ToString());
        }
    }

    public static string GetDaysPassed()
    {
        today = System.DateTime.Now;

        //days between today and start date -->
        System.TimeSpan elapsed = today.Subtract(startDate);

        double days = elapsed.TotalDays;

        return days.ToString("days passed " + "0");
    }



    public void PopulatePlantData(Plant plant, string referenceName, int referenceChildName, DateTime childrenReference)
    {
        var RootRef = FireBase.DBreference = FirebaseDatabase.DefaultInstance.GetReference("Plant" + " for user " + USERID);
        var currDate = currentDate = DateTime.Now;
        plant.Height = 5;// HERE ASIGN THE VALUES FROM THE DRONE POPUP ON WHAT TO CHANGE
        plant.Weight = 10;
        string res = JsonUtility.ToJson(plant);
        RootRef.Child(referenceName).Child("PlantID " + referenceChildName.ToString()).Child(childrenReference.ToString()).SetRawJsonValueAsync(res);
        PlayerPrefs.SetString("ID", USERID);


    }


    // this is not used at this moment, but it will be changed in the future
    public void PopulateHexData(string referenceName, int referenceChildName)
    {
        var HexRootRef = FireBase.DBreference = FirebaseDatabase.DefaultInstance.GetReference("Hex");
        var currDate = currentDate = DateTime.Now;
        Hex hex = new Hex();
        hex.UserId = USERID;
        hex.HexID = TempPlantID;
        string res = JsonUtility.ToJson(hex);
    }

    DroneUIManager droneUiManager;
    SingleDrone drone;
 
}
