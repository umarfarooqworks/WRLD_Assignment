using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserData
{
}

[System.Serializable]
public class PIOModels
{
    public int id;
    public string title;
    public string subtitle;
    public string lat;
    public string lon;
    public string height_offset;
    public bool indoor;
    public string indoor_id;
    public int floor_id;
    public UserData user_data;
    public string tags;
}

[System.Serializable]
public class PIOModelCollection
{
    public PIOModels[] lines;
}
