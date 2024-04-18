using System.Collections;
using System.Collections.Generic;
using LudumDare55;
using UnityEngine;

[CreateAssetMenu(fileName = "DataContainer", menuName = "Storage/NewDataContainer")]
public class GameDataContainer : ScriptableObject
{
    public List<Demon> allDemons;
    public List<Setup> allSetups;
}
