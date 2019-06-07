using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager : MonoBehaviour
{
    #region shoot data
    public GameObject arrow; //prefab of an arrow
    float timer = 0;
    public GameObject projectile;
    #endregion

    private void Awake()
    {
        //provisory arrow to test shoot
        FindObjectOfType<InputManager>()._onMouseLeftClic += ClicDetect;
    }

    // Start is called before the first frame update
    void Start()
    {
        #region setting clic input
        DataContainer.singleton.ShotData.shot.canshoot = true;//temporary
        #endregion
    }

    // Update is called once per frame
    void Update()
    {



    }
    #region shooting method
    private void ShootingArrow(float power, GameObject arrowToShot)
    {       //throw the arrow

        Rigidbody rb = arrowToShot.GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.up * power, ForceMode.Impulse);
        rb.useGravity = true;

    }
    private float GetPower(float time)
    {
        //clamping power value between min and max
        float power = Mathf.Clamp((Time.time - timer) / DataContainer.singleton.ShotData.shot.maxTime, DataContainer.singleton.ShotData.shot.minForce, DataContainer.singleton.ShotData.shot.maxForce);
        return power;
    }
    #endregion


    public void ClicDetect(object o, InputManager.OnMouseClicEventArgs e)
    {
        //catch the clic event
        if (e.MouseOnClicDown)
        {
            projectile = Instantiate(arrow, transform.position, transform.localRotation * Quaternion.Euler(new Vector3(90, 1, 1)));
            timer = Time.time;
        }
        if (e.MouseOnClicUp && projectile != null)
        {
            ShootingArrow(GetPower(timer), projectile);
        }
    }
}


      
