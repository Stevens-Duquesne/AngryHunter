using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.B))
        {
            Time.timeScale = 0;
        }
        else if(Input.GetKey(KeyCode.P))
        {
            Time.timeScale = 1;
        }

    }
}
