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
        projectile = Instantiate(arrow, transform.position, Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        #region setting clic input
        FindObjectOfType<InputManager>()._onMouseLeftClic += ClicDetect;
        projectile.SetActive(true);
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
      if(DataContainer.singleton.ShotData.shot.canshoot && projectile.activeSelf) //replace by a checkQuiver value method
        {
            projectile.transform.rotation = gameObject.transform.rotation;
            projectile.transform.position = gameObject.transform.position + Vector3.forward;

            if(trigger)
            {
                timer += Time.deltaTime;

            }
            else
            {
                ShootingArrow(GetPower(timer), projectile);
                timer = 0;
            }
        }

       
    }
    #region shooting method
    private void ShootingArrow(float power,GameObject arrowToShot)
    {
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
        trigger = e.MouseClicState;
    }
}
