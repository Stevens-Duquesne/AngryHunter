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
        public  bool acceleration;
        public List<GameObject> Quiver; //ne marche pas bien je vais demander a Ambroise pour une alternative
    }
    public Player player;
   


}