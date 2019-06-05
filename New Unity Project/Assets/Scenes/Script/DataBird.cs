using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "DataBird", menuName = "Data/BirdData", order = 2)]
public class DataBird : ScriptableObject
{
    [System.Serializable]
    public class Bird
    {
        
    }
    public Bird bird;
}


