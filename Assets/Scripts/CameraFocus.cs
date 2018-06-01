using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class CameraFocus : MonoBehaviour {

    void Update () {
		if (!CameraDevice.Instance.SetFocusMode (CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO)) {
			CameraDevice.Instance.SetFocusMode (CameraDevice.FocusMode.FOCUS_MODE_NORMAL);
		}
        if (Screen.orientation == ScreenOrientation.Portrait)
            return;
        Screen.orientation = ScreenOrientation.Portrait;

    }
}
