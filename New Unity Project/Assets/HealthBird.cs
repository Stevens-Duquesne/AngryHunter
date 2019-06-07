using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBird : MonoBehaviour
{
    public float Health = 20f;
    public float timeDestArow = 5.0f;


    
    public void RemoveHealth(float amount)
    {
        Health -= amount;
        if(Health <= 0)
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
            Destroy(other.gameObject, timeDestArow);

        }

    }

 


}
