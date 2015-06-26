using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MultiMonitorScreenSpace.Utility
{
    public static class Utils
    {
        public static Rect mainScreen; // the primary display port
        public static Dictionary<Camera, Rect> CamsResized = new Dictionary<Camera, Rect>();

        public static void resizeViewPort(Camera c)
        {
            if (!CamsResized.ContainsKey(c))
            {
                Rect r = c.pixelRect;
                r.x = r.x * mainScreen.width / Screen.width + mainScreen.x;
                r.width = r.width * mainScreen.width / Screen.width;
                c.pixelRect = r;
                if (!CamsResized.ContainsKey(c))
                    CamsResized.Add(c, c.pixelRect);
            }
            else if (c.pixelRect != CamsResized[c])
            {
                c.pixelRect = new Rect(CamsResized[c]);
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
            CamsResized.Add(blackoutCamLeft, blackoutCamLeft.pixelRect);

            cameraObjectRight = new GameObject("ExtraScreenBackgroundRight");
            UnityEngine.MonoBehaviour.DontDestroyOnLoad(cameraObjectRight);
            blackoutCamRight = cameraObjectRight.AddComponent<Camera>();
            blackoutCamRight.name = "BlackoutCameraRight";
            blackoutCamRight.CopyFrom(blackoutCamLeft);
            blackoutCamRight.pixelRect = new Rect(Utils.mainScreen.x + Utils.mainScreen.width, 0, Screen.width - Utils.mainScreen.xMax, Screen.height);
            CamsResized.Add(blackoutCamRight, blackoutCamRight.pixelRect);
        }

        public static void setUIAnchors()
        {
            ScreenSafeUI UI = ScreenSafeUI.fetch;
            if (UI.rightAnchor.bottom != null)
            {
                UI.rightAnchor.bottom.position = new Vector3(UI.rightAnchor.bottom.position.x * 0.5f, UI.rightAnchor.bottom.position.y, UI.rightAnchor.bottom.position.z);
                if (UI.leftAnchor.bottom != null)
                    UI.centerAnchor.bottom.position = (UI.leftAnchor.bottom.position + UI.rightAnchor.bottom.position) * 0.5f;
            }
            if (UI.rightAnchor.center != null)
            {
                UI.rightAnchor.center.position = new Vector3(UI.rightAnchor.center.position.x * 0.5f, UI.rightAnchor.center.position.y, UI.rightAnchor.center.position.z);
                if (UI.leftAnchor.center != null)
                    UI.centerAnchor.center.position = (UI.leftAnchor.center.position + UI.rightAnchor.center.position) * 0.5f;
            }
            if (UI.rightAnchor.top)
            {
                UI.rightAnchor.top.position = new Vector3(UI.rightAnchor.top.position.x * 0.5f, UI.rightAnchor.top.position.y, UI.rightAnchor.top.position.z);
                if (UI.leftAnchor.top != null)
                    UI.centerAnchor.top.position = (UI.leftAnchor.top.position + UI.rightAnchor.top.position) * 0.5f;   
            }
        }
    }
}