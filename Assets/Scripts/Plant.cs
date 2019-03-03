using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Plant
{
    public int PlantID;
    public float Height = 1;
    public float LeavesQuantity = 1;
    public float LeavesWidth = 1;
    public float Weight = 1;
    public float HeatofPlant = 1;
    public float ColorofPlant = 1;
    public float SoilCover = 1;
}

[Serializable]
public class Hex
{
    public string UserId;
    public int HexID;
    public string value1;
}

[Serializable]
public class AllHexes
{
    public List<Hex> Hexes;
}

[Serializable]
public class AllPlants
{
    public List<Plant> Plants;
}

