using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSupply : MonoBehaviour
{
    private int arrowsLeft;
    private int arrowAdd = 5;
    private int arrowsToAdd;
    // Start is called before the first frame update
    void Start()
    {
        arrowsLeft = DataContainer.singleton.PlayerData.player.arrowInQuiver;
    }

    private void OnCollisionEnter(Collision collision)
    {
        arrowsToAdd = arrowsLeft += arrowAdd;

    }
}
