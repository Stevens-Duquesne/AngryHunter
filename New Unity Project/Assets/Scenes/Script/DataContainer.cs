using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataContainer : MonoBehaviour
{
    public static DataContainer singleton;
    public DataPlayer PlayerData;
    public DataShoot ShotData;
    public DataBird BirdData;
    void Awake()
    {
        if (singleton != null)
            Destroy(gameObject);
        else
            singleton = this;
    }

}