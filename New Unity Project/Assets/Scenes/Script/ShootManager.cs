using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    #region shoot data

    float maxForce;//maximum strength output for the shot
    float minForce;//minimum strength output for the shot

    Quaternion shotAngle; //Angle wich is used for the arrow starting position  (modified in update with camera current angle).
    public GameObject Arrow; //prefav of the arrow we want to instanciate and shoot.(temporary cause we can use an inventory).
    float timer = 0;
    #endregion
    #region camera view
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
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb)
            rb.freezeRotation = true;
        originalRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {

        //if (FindObjectOfType<InputManager>().OnMouseRClicDown())
        //{
        //    timer += Time.deltaTime;
        //}


        //if (FindObjectOfType<InputManager>().OnMouseRClicUp())
        //{
        //    ShootingArrow(GetPower(timer));
        //}

        #region camera view update
        if (axes == RotationAxes.MouseXAndY)
        {
            rotAverageX = 0f;
            rotAverageY = 0f;

            //rotationY += FindObjectOfType<InputManager>().OnMouseUse("MouseY");
            // rotationX += FindObjectOfType<InputManager>().OnMouseUse("MouseX");

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

            //  rotationX += FindObjectOfType<InputManager>().OnMouseUse("MouseX");

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

            // rotationY += FindObjectOfType<InputManager>().OnMouseUse("MouseY");

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
        //onclicrelease shooting

        //reset timer
        timer = 0;

    }
    private float GetPower(float time)
    {
        //clamping power value on min and max

        return 0;
    }
    #endregion

    #region camera view clamping
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
}
