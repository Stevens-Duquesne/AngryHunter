using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ShootingData", menuName = "Data/ShootingData", order = 1)]
public class DataShoot : ScriptableObject
{
    [System.Serializable]
    public class Shot
    {
        public bool canshoot=false;
        public float maxForce=0;//maximum strength output for the shot
        public float minForce=0;//minimum strength output for the shot
        Quaternion shotAngle=Quaternion.identity; //Angle wich is used for the arrow starting position  
    }
    public Shot shot;
}


