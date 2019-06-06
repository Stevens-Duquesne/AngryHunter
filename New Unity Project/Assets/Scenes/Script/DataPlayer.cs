using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName ="PlayerData", menuName ="Data/PlayerData",order= 0)]
public class DataPlayer : ScriptableObject
{
    [System.Serializable]
    public  class Player
    {
        public  float speed;
        public  bool jumpAllowed;
        public float jumpIntensity;
        public  bool acceleration;
        public GameObject Arrow;
        public int arrowInQuiver;
    }
    public Player player;
   


}