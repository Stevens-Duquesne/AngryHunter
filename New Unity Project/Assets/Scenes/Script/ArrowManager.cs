using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position += Vector3.forward;
        FindObjectOfType<ShootView>()._onCamRotate += ArrowRotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ArrowRotation(object o, ShootView.OnCamRotateEventArgs e)
    {
        if (gameObject.GetComponent<Rigidbody>().velocity == Vector3.zero)
        {
            transform.rotation = e.CamAngles * Quaternion.Euler(new Vector3(90, 1, 1));
        }
    }
    private void OnDestroy()
    {
        FindObjectOfType<ShootView>()._onCamRotate -= ArrowRotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
            Destroy(gameObject);
    }
}
