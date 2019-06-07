using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthMonster : MonoBehaviour
{
    public float Health = 70f;



    public void RemoveHealth(float amount)
    {
        Health -= amount;
        if (Health <= 0)
        {
            Destroy(gameObject);

        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "arow")
        {
            Destroy(other.gameObject, 2);

        }


    }
}
