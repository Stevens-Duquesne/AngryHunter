using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    public void OnArrowPressedListener(object o, InputManager.OnKeyPressedEventArgs e)
    {
        transform.Translate( new Vector3((float)e.axe.x,(float)e.axe.y));
    }




    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<InputManager>()._onKeyPressed += OnArrowPressedListener;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
