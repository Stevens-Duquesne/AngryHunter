using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager : MonoBehaviour
{
    #region shoot data
    public GameObject arrow; //prefab of an arrow
    float timer = 0;
    bool trigger;
    #endregion

   
  
    // Start is called before the first frame update
    void Start()
    {
        #region setting clic input
        FindObjectOfType<InputManager>()._onMouseLeftClic += ClicDetect;
        #endregion
       
      

    }

    // Update is called once per frame
    void Update()
    {
      
       
    }
    #region shooting method
    private void ShootingArrow(float power)
    {


            //clic check
            //arrow ready to shot check
            //maintaining clic increase power through time + clamping values in get power and translate the arrow back slowly.
            //when clic released arrow is shot with the calculated power and the correct angle.

    }
    private float GetPower(float time)
    {
        //clamping power value on min and max
        float power= Mathf.Clamp(timer, DataContainer.singleton.ShotData.shot.minForce, DataContainer.singleton.ShotData.shot.maxForce);
        return power;
    }
    #endregion

   
    public void ClicDetect(object o,InputManager.OnMouseClicEventArgs e)
    {
        trigger = e.MouseClicState;
    }
}
