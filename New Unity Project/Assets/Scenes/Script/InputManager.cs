using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public event UnityAction Move;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move += GetAxis;
        Move += GetRotation;
    }
    void GetAxis ()
    {
       
    }
    void GetRotation()
    {

    }
}

