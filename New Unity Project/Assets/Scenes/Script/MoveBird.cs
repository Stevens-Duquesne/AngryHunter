using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoveBird : MonoBehaviour
{

    public float Force = 10.0f;
    public Vector3 direction;










    void Start()
    {

    }









    void Update()
    {

       
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
            {
            direction = Vector3.Normalize(gameObject.transform.position - collision.transform.position);
            Rigidbody rb =GetComponent<Rigidbody>();
            rb.AddRelativeForce(direction * 1000, ForceMode.Impulse);
            Debug.Log("Fuire!");

            }

       
 
    }

}





