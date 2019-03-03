using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    //THIS CLASS WILL BE INPLEMENTED SOON ON EACH DRONE
    [Serializable]
    public class SingleDrone
    {
        public int DroneID;
        public int DronePlantIDAssignment;
        public string DroneInfo;
        public DateTime DroneStartedWorkingTime;
        public DateTime DroneStoppedWorkingTime;
    }

