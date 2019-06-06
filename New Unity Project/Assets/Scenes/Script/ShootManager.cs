using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager : MonoBehaviour
{
    #region shoot data
    public GameObject arrow; //prefab of an arrow
    float timer = 0;
    #endregion

    #region camera view experimental
    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensivityX = 20F, sensivityY = 20F;

    public float minimumX = -360F, maximumX = 360F;
    public float minimumY = -60F, maximumY = 60F;

    float rotationX = 0F, rotationY = 0;

    private List<float> rotArrayX = new List<float>();
    float rotAverageX = 0F;
    private List<float> rotArrayY = new List<float>();
    float rotAverageY = 0F;

    public float frameCounter = 20;
    Quaternion originalRotation;
    #endregion
  
    // Start is called before the first frame update
    void Start()
    {
        #region setting view input
        FindObjectOfType<InputManager>()._onMousetranslate += CatchMouse;
        FindObjectOfType<InputManager>()._onMouseLeftClic += ClicDetect;
        #endregion
        #region experimental
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb)
            rb.freezeRotation = true;
        originalRotation = transform.localRotation;

        //fill the quiver with 5 arrows to start
      
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
      
        #region camera view update experimental
        if (axes == RotationAxes.MouseXAndY)
        {
            rotAverageX = 0f;
            rotAverageY = 0f;

            rotArrayY.Add(rotationY);
            rotArrayX.Add(rotationX);

            if (rotArrayY.Count >= frameCounter)
            {
                rotArrayY.RemoveAt(0);
            }
            if (rotArrayX.Count >= frameCounter)
            {
                rotArrayX.RemoveAt(0);
            }

            for (int j = 0; j < rotArrayY.Count; j++)
            {
                rotAverageY += rotArrayY[j];
            }
            for (int i = 0; i < rotArrayX.Count; i++)
            {
                rotAverageX += rotArrayX[i];
            }

            rotAverageY /= rotArrayY.Count;
            rotAverageX /= rotArrayX.Count;

            rotAverageX = ClampAngle(rotAverageX, minimumX, maximumX);
            rotAverageY = ClampAngle(rotAverageY, minimumY, maximumY);

            Quaternion yQuaternion = Quaternion.AngleAxis(rotAverageY, Vector3.left);
            Quaternion xQuaternion = Quaternion.AngleAxis(rotAverageX, Vector3.up);

            transform.localRotation = originalRotation * xQuaternion * yQuaternion;
        }
        else if (axes == RotationAxes.MouseX)
        {
            rotAverageX = 0f;

            rotArrayX.Add(rotationX);

            if (rotArrayX.Count >= frameCounter)
            {
                rotArrayX.RemoveAt(0);
            }
            for (int i = 0; i < rotArrayX.Count; i++)
            {
                rotAverageX += rotArrayX[i];
            }
            rotAverageX /= rotArrayX.Count;

            rotAverageX = ClampAngle(rotAverageX, minimumX, maximumX);

            Quaternion xQuaternion = Quaternion.AngleAxis(rotAverageX, Vector3.up);
            transform.localRotation = originalRotation * xQuaternion;
        }
        else
        {
            rotAverageY = 0f;

            rotArrayY.Add(rotationY);

            if (rotArrayY.Count >= frameCounter)
            {
                rotArrayY.RemoveAt(0);
            }
            for (int j = 0; j < rotArrayY.Count; j++)
            {
                rotAverageY += rotArrayY[j];
            }
            rotAverageY /= rotArrayY.Count;

            rotAverageY = ClampAngle(rotAverageY, minimumY, maximumY);

            Quaternion yQuaternion = Quaternion.AngleAxis(rotAverageY, Vector3.left);
            transform.localRotation = originalRotation * yQuaternion;
        }
        #endregion
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

    #region camera view clamping experimental
    public static float ClampAngle(float angle, float min, float max)
    {
        angle = angle % 360;
        if ((angle >= -360F) && (angle <= 360F))
        {
            if (angle < -360F)
            {
                angle += 360F;
            }
            if (angle > 360F)
            {
                angle -= 360F;
            }
        }
        return Mathf.Clamp(angle, min, max);
    }

    #endregion
    public void CatchMouse(object o, InputManager.OnMouseTranslationEventArgs e)
    {
        rotationX += e.translationMove.x * sensivityX;
        rotationY += e.translationMove.y * sensivityY;
    }
    public void ClicDetect(object o,InputManager.OnMouseClicEventArgs e)
    {
      
    }
}
