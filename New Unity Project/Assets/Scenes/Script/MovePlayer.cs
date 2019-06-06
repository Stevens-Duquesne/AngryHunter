using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    Rigidbody rb;
    private bool IsColliding;

    public void OnArrowPressedListener(object o, InputManager.OnKeyPressedEventArgs e)
    {
        transform.Translate(new Vector3((float)e.axe.x, 0, (float)e.axe.y) * DataContainer.singleton.PlayerData.player.speed , Space.World);
        
    }
    public void OnSpacePressedListener(object o, InputManager.OnSpaceJumpEventArgs e)
    {
        if (IsColliding == false) // Vérifie l'état de la colision avec le tag terrain.
        {
            if (DataContainer.singleton.PlayerData.player.jumpAllowed)
            {
                if (rb != null)
                    rb.AddRelativeForce(0, DataContainer.singleton.PlayerData.player.jumpIntensity, 0, ForceMode.Force);
            }
        }


    }



    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<InputManager>()._onKeyPressed += OnArrowPressedListener;
        FindObjectOfType<InputManager>()._onSpaceJump += OnSpacePressedListener;
        rb = GetComponent<Rigidbody>();
    }


    private void OnCollisionEnter(Collision collision) //Si colision Enter est Faux.
    {
        if (collision.gameObject.name == "Terrain")
        {
            IsColliding = false;
        }
    }
    private void OnCollisionExit(Collision collision) //Si colision Exit est true, empêcher le joueur de pouvoir relancer le jump.
    {
        if (collision.gameObject.name == "Terrain")
        {
            IsColliding = true;
        }
    }
}
