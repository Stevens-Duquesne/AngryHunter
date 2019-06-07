using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovePlayer : MonoBehaviour
{
    #region Event
    public class OnPositionCubeEventArgs : EventArgs
    {
        public Vector3 positionCube;
    }
    public EventHandler<OnPositionCubeEventArgs> _onCubeMove;
    private void OnCubePosition(OnPositionCubeEventArgs args)
    {
        if (_onCubeMove != null)
            _onCubeMove(this, args);
    }

    #endregion
    Rigidbody rb;
    private bool IsColliding;
    private bool iMove=false;
    private void Awake()
    {
        FindObjectOfType<ShootView>()._onCamRotate += CubeRotation;
    }
    public void OnArrowPressedListener(object o, InputManager.OnKeyPressedEventArgs e)
    {
        Vector3 direction= new Vector3((float)e.axe.x, 0f, (float)e.axe.y);
        iMove = true;
        transform.Translate(direction * DataContainer.singleton.PlayerData.player.speed, Space.World);
        
    }
    public void OnSpacePressedListener(object o, InputManager.OnSpaceJumpEventArgs e)
    {
        
        if (IsColliding == true) // Vérifie l'état de la colision avec le tag terrain.
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
            IsColliding = true;
        }
    }
    private void OnCollisionExit(Collision collision) //Si colision Exit est true, empêcher le joueur de pouvoir relancer le jump.
    {
        if (collision.gameObject.name == "Terrain")
        {
            IsColliding = false;
        }
    }
    private void Update()
    {
        if (iMove)
        {
            OnCubePosition(new OnPositionCubeEventArgs { positionCube = gameObject.transform.position});
        }
    }
    public void CubeRotation(object o,ShootView.OnCamRotateEventArgs e)
    {
        transform.rotation = new Quaternion(e.CamAngles.x,0f,e.CamAngles.z,0f);
    }
}
