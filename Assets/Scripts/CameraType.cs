using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class CameraType : MonoBehaviour {

    CameraDevice device = CameraDevice.Instance;
    CameraDevice.CameraDirection direction;

    /*private IEnumerator Start()
    {
        yield return new WaitForSeconds(0.1f);
        StopTracker();
    }*/

    public void DeactivateDataSet()
    {
        TrackerManager.Instance.DeinitTracker<ObjectTracker>();
    }

    public void ActivateDataSet()
    {
        TrackerManager.Instance.InitTracker<ObjectTracker>();
    }

	public void StopTracker()
    {
        TrackerManager.Instance.GetTracker<ObjectTracker>().Stop();
    }

    public void StartTracker()
    {
        TrackerManager.Instance.GetTracker<ObjectTracker>().Start();
    }

    public void StopCamera()
    {
        device.Stop();
    }

    public void StartCamera()
    {
        device.Start();
    }

    public void DeInitCamera()
    {
        device.Deinit();
    }

    public void SetDirectionCamera(CameraDevice.CameraDirection direction)
    {
        device.Init(direction);
    }

    public void ActivateCamera()
    {
        StopCamera();
        DeInitCamera();
        device.Init(CameraDevice.CameraDirection.CAMERA_DEFAULT);
        StartCamera();
    }

    public void ActivateAR()
    {
        StopTracker();
        ActivateCamera();
        StartTracker();
    }

    public void ChangeCameraDirection()
    {
        if (device.GetCameraDirection() == CameraDevice.CameraDirection.CAMERA_BACK)
        {
            direction = CameraDevice.CameraDirection.CAMERA_FRONT;
        }
        else
        {
            direction = CameraDevice.CameraDirection.CAMERA_BACK;
        }
        StopTracker();
        StopCamera();
        DeInitCamera();
        SetDirectionCamera(direction);
        StartCamera();
        StartTracker();

    }

}
