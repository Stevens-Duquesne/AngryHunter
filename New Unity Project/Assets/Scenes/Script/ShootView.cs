using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShootView : MonoBehaviour
{
    #region Event
    public class OnCamRotateEventArgs : EventArgs
    {
        public Quaternion CamAngles;
    }
    public EventHandler<OnCamRotateEventArgs> _onCamRotate;
    private void OnCamRotate(OnCamRotateEventArgs args)
    {
        if (_onCamRotate != null)
            _onCamRotate(this, args);
    }

    #endregion

    #region camera view experimental
    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensivityX = 0.2F, sensivityY = 0.2F;

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
        FindObjectOfType<MovePlayer>()._onCubeMove += CatchCube;
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
        OnCamRotate(new OnCamRotateEventArgs { CamAngles = transform.localRotation });
        #endregion
    } 

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
   public void CatchCube(object o , MovePlayer.OnPositionCubeEventArgs e)
    {
        transform.position = e.positionCube;
    }
}
