using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataQuiver", menuName = "Data/QuiverData", order = 2)]
public class QuiverManager : ScriptableObject
{
    [System.Serializable]
    public class Carquois
    {
        public GameObject prefab;
    }

    [SerializeField]
    private List<Carquois> arrows;

    
}
