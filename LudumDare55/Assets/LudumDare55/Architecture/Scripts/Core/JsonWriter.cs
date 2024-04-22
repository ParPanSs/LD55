using System;
using System.Collections;
using System.Collections.Generic;
using LudumDare55;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;
using File = System.IO.File;

public class JsonWriter : MonoBehaviour
{
    private string saveFilePath = Application.dataPath + "/Setups.json";
    public CreateScriptableObjectOfSetup[] sos;
    public List<Demon> demons;
    public List<Setup> setups;

    public GameDataContainer dataCont;
    //public List<> demons;
    public string json;
    
    
    [ContextMenu("GenerateJson")]
    private void GenerateJson()
    {
        string str = "";
        foreach (var so in sos)
        {
            str += JsonUtility.ToJson(so, true);
            str += ",\n";
        }
        Debug.Log(str);
        SaveFile(str);
    }
    
    [ContextMenu("LoadFromJson")]
    private void LoadFromJson()
    {
        var root = JsonUtility.FromJson<RootObject>(json);
        //demons = root.DemonData;
        Debug.Log(root.SetupData.Count);
        setups = root.SetupData;
    }

    [ContextMenu("WriteToContainer")]
    private void WriteData()
    {
        dataCont.allDemons = demons;
        dataCont.allSetups = setups;
    }

    private void SaveFile(string fileData)
    {
        File.WriteAllText(saveFilePath, fileData);
    }
    
    
}

[Serializable]
public class RootObject
{
    //public List<Demon> DemonData;
    public List<Setup> SetupData;
}


