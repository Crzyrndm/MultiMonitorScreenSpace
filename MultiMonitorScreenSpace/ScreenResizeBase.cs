using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace MapViewTest
{
    [KSPAddon(KSPAddon.Startup.EveryScene, false)]
    public class ScreenResizeBase : MonoBehaviour
    {
        public static float requestedWidth;
        public static HashSet<string> CamsResized;
        Camera blackoutCam;
        GameObject cameraObject;
        Rect mainScreenArea;

        public void Start()
        {
            if (HighLogic.LoadedSceneIsEditor)
                return; // editor gets funky. Huge fisheye effect and part centered on screen not camera
            if (CamsResized == null)
                CamsResized = new HashSet<string>();
            requestedWidth = 1920;
            mainScreenArea = new Rect(0, 0, requestedWidth, Screen.height);
            foreach (Camera c in Camera.allCameras)
            {
                if (CamsResized.Contains(c.name))
                    continue;
                Rect r = c.pixelRect;
                r.x = r.x * requestedWidth / Screen.width;
                r.width = r.width * requestedWidth / Screen.width;
                c.pixelRect = r;
                CamsResized.Add(c.name);
            }

            cameraObject = new GameObject("ExtraScreenBackground");
            blackoutCam = cameraObject.AddComponent<Camera>();
            blackoutCam.depth = 5;
            blackoutCam.pixelRect = new Rect(requestedWidth, 0, Screen.width - requestedWidth, Screen.height);
            blackoutCam.backgroundColor = Color.black;
            blackoutCam.clearFlags = CameraClearFlags.SolidColor;
            blackoutCam.cullingMask = 0;
        }

        public void Update()
        {
            if (!mainScreenArea.Contains(Input.mousePosition))
            {
                InputLockManager.SetControlLock(ControlTypes.CAMERACONTROLS, "ScreenExtenderLock");
            }
            else
            {
                InputLockManager.RemoveControlLock("ScreenExtenderLock");
            }
        }

        public void LateUpdate()
        {
        }

        public void OnDestroy()
        {
            if (cameraObject != null)
                Destroy(cameraObject);
        }
    }
}
