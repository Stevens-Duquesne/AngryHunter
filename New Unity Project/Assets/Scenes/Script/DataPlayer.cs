using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName ="PlayerData", menuName ="Data/PlayerData",order= 0)]
public class DataPlayer : ScriptableObject
{
    [System.Serializable]
    public class Player
    {
        public static float speed;
        public static bool jumpAllowed;
        public static bool acceleration;
        public static Stack<GameObject> Quiver;
    }
    public static Player player;


}