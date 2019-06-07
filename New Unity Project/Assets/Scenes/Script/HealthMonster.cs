using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthMonster : MonoBehaviour
{
    public float Health = 20f;



    public void RemoveHealth(float amount)
    {


    }

    // Update is called once per frame
    void Update()
    {

    }

    /*private void Awake()
    {
        FindObjectOfType<HeadBird>()._onHeadShoot += DetectHeadShoot;
        FindObjectOfType<BodyBird>()._onBodyShoot += DetectBodyShoot;
    }
    public void DetectHeadShoot(object o, HeadBird.OnHeadShootEventArgs e)
    {
        if (e.HeadShoot)
        {
            Health -=Health;
            CheckHealth();
        }
    }
    public void DetectBodyShoot(object o, BodyBird.OnBodyShootEventArgs e)
    {
        if (e.BodyShoot)
        {
            Health -= 10f;
            CheckHealth();

        }
    }*/
        private void CheckHealth()
        {
            if (Health <= 0)
            {
               // FindObjectOfType<BodyBird>()._onBodyShoot -= DetectBodyShoot;
               // FindObjectOfType<HeadBird>()._onHeadShoot -= DetectHeadShoot;
                Destroy(gameObject);
            }
        }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "arow")
        {
            Health -= 10f;
            CheckHealth();
            Destroy(collision.gameObject);
        }
    }

}
