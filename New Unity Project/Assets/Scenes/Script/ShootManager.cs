using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager : MonoBehaviour
{
    #region shoot data
    public GameObject arrow; //prefab of an arrow
    float timer = 0;
    bool trigger;
    bool shootPermission;
    GameObject projectile;
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
        DataContainer.singleton.ShotData.shot.canshoot= true;//temporary
        projectile = Instantiate(arrow, transform.position + Vector3.up * 2, transform.rotation * Quaternion.Euler(new Vector3(90, 0, 0)));
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        if (projectile != null)
        {
            projectile.transform.rotation = transform.rotation * Quaternion.Euler(new Vector3(90, 0, 0));
            projectile.transform.position = gameObject.transform.position + Vector3.forward;
        }
        if (shootPermission) //replace by a checkQuiver value method
        {
            if(trigger)
            {
                timer += Time.deltaTime;

            }
            else if (!trigger && shootPermission)
            {
                ShootingArrow(GetPower(timer), projectile);
                timer = 0;
            }
        }

       
    }
    #region shooting method
    private void ShootingArrow(float power,GameObject arrowToShot)
    {       //throw the arrow
        projectile = Instantiate(arrow, transform.position + Vector3.up * 2, transform.rotation * Quaternion.Euler(new Vector3(90, 0, 0)));
        Rigidbody rb = arrowToShot.GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.forward*power, ForceMode.Impulse);

    }
    private float GetPower(float time)
    {
        //clamping power value between min and max
        float power= Mathf.Clamp(timer, DataContainer.singleton.ShotData.shot.minForce, DataContainer.singleton.ShotData.shot.maxForce);
        return power;
    }
    #endregion

   
    public void ClicDetect(object o,InputManager.OnMouseClicEventArgs e)
    {
        if(e.MouseClicState)
        {
            trigger = true;
        }
        shootPermission = e.MouseOnClic;
    }
}
