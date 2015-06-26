using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MultiMonitorScreenSpace
{
    public static class Utils
    {
        public static Rect mainScreen; // the primary display port
        public static HashSet<string> CamsResized = new HashSet<string>(); // all cameras that have already been resized

        public static void resizeViewPort(Camera c, bool force = false)
        {
            if (c.name == "EZGUI Cam" && !force)
                return;
            if (!CamsResized.Contains(c.name) || c.pixelRect.width == Screen.width || force)
            {
                Rect r = c.pixelRect;
                r.x = r.x * mainScreen.width / Screen.width + mainScreen.x;
                r.width = r.width * mainScreen.width / Screen.width;
                c.pixelRect = r;
                if (!CamsResized.Contains(c.name))
                    CamsResized.Add(c.name);
            }
        }

        public static Camera blackoutCamLeft, blackoutCamRight;
        public static GameObject cameraObjectLeft, cameraObjectRight;
        public static void createBlackoutCameras()
        {
            if (cameraObjectLeft != null)
                return;

            cameraObjectLeft = new GameObject("ExtraScreenBackgroundLeft");
            UnityEngine.MonoBehaviour.DontDestroyOnLoad(cameraObjectLeft);
            blackoutCamLeft = cameraObjectLeft.AddComponent<Camera>();
            blackoutCamLeft.name = "BlackoutCameraLeft";
            blackoutCamLeft.depth = 5;
            blackoutCamLeft.backgroundColor = Color.black;
            blackoutCamLeft.clearFlags = CameraClearFlags.SolidColor;
            blackoutCamLeft.cullingMask = 0;
            blackoutCamLeft.pixelRect = new Rect(0, 0, Utils.mainScreen.x, Screen.height);
            CamsResized.Add(blackoutCamLeft.name);

            cameraObjectRight = new GameObject("ExtraScreenBackgroundRight");
            UnityEngine.MonoBehaviour.DontDestroyOnLoad(cameraObjectRight);
            blackoutCamRight = cameraObjectRight.AddComponent<Camera>();
            blackoutCamRight.name = "BlackoutCameraRight";
            blackoutCamRight.CopyFrom(blackoutCamLeft);
            blackoutCamRight.pixelRect = new Rect(Utils.mainScreen.x + Utils.mainScreen.width, 0, Screen.width - Utils.mainScreen.xMax, Screen.height);
            CamsResized.Add(blackoutCamRight.name);
        }
    }
}