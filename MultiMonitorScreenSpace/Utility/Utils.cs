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
                r.x = mainScreen.x + r.x * mainScreen.width / Screen.width;
                r.y = mainScreen.y + r.y * mainScreen.height / Screen.height;
                r.width = r.width * mainScreen.width / Screen.width;
                r.height = r.height * mainScreen.height / Screen.height;
                c.pixelRect = r;
                CamsResized.Add(c, c.pixelRect);
            }
            else if (c.pixelRect != CamsResized[c])
            {
                c.pixelRect = new Rect(CamsResized[c]);
            }
        }

        public static Camera blackoutCamLeft, blackoutCamRight, blackoutCamTop, blackoutCamBottom;
        public static GameObject cameraObjectLeft, cameraObjectRight, cameraObjectTop, cameraObjectBottom;
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
            blackoutCamLeft.pixelRect = new Rect(0, 0, mainScreen.x, Screen.height);
            CamsResized.Add(blackoutCamLeft, blackoutCamLeft.pixelRect);

            cameraObjectRight = new GameObject("ExtraScreenBackgroundRight");
            UnityEngine.MonoBehaviour.DontDestroyOnLoad(cameraObjectRight);
            blackoutCamRight = cameraObjectRight.AddComponent<Camera>();
            blackoutCamRight.CopyFrom(blackoutCamLeft);
            blackoutCamRight.name = "BlackoutCameraRight";
            blackoutCamRight.pixelRect = new Rect(mainScreen.x + mainScreen.width, 0, Screen.width - (mainScreen.x + mainScreen.width), Screen.height);
            CamsResized.Add(blackoutCamRight, blackoutCamRight.pixelRect);

            cameraObjectTop = new GameObject("ExtraScreenBackgroundTop");
            UnityEngine.MonoBehaviour.DontDestroyOnLoad(cameraObjectTop);
            blackoutCamTop = cameraObjectTop.AddComponent<Camera>();
            blackoutCamTop.CopyFrom(blackoutCamLeft);
            blackoutCamTop.name = "BlackoutCameraTop";
            blackoutCamTop.pixelRect = new Rect(mainScreen.x, 0, mainScreen.x + mainScreen.width, mainScreen.y);
            CamsResized.Add(blackoutCamTop, blackoutCamTop.pixelRect);

            cameraObjectBottom = new GameObject("ExtraScreenBackgroundBottom");
            UnityEngine.MonoBehaviour.DontDestroyOnLoad(cameraObjectBottom);
            blackoutCamBottom = cameraObjectBottom.AddComponent<Camera>();
            blackoutCamBottom.CopyFrom(blackoutCamLeft);
            blackoutCamBottom.name = "BlackoutCameraBottom";
            blackoutCamBottom.pixelRect = new Rect(mainScreen.x, mainScreen.y + mainScreen.height, mainScreen.x + mainScreen.width, Screen.height - (mainScreen.y + mainScreen.height));
            CamsResized.Add(blackoutCamBottom, blackoutCamBottom.pixelRect);
        }

        /// <summary>
        /// sets screen space for SSUI system (main flight UI, parts of editor and main menu)
        /// </summary>
        public static void setUIAnchors()
        {
            ScreenSafeUI UI = ScreenSafeUI.fetch;
            // 1 unit = GameSettings.UI_Size
            if (UI.rightAnchor.bottom != null)
                UI.rightAnchor.bottom.position = new Vector3((mainScreen.x + mainScreen.width) / GameSettings.UI_SIZE, 0, 0);
            if (UI.centerAnchor.bottom != null)
                UI.centerAnchor.bottom.position = new Vector3((mainScreen.x + 0.5f * mainScreen.width) / GameSettings.UI_SIZE, 0, 0);
            if (UI.leftAnchor.bottom != null)
                UI.leftAnchor.bottom.position = new Vector3(mainScreen.x / GameSettings.UI_SIZE, 0, 0);
            if (UI.rightAnchor.center != null)
                UI.rightAnchor.center.position = new Vector3((mainScreen.x + mainScreen.width) / GameSettings.UI_SIZE, (mainScreen.y + 0.5f * mainScreen.height) / GameSettings.UI_SIZE, 0);
            if (UI.centerAnchor.center != null)
                UI.centerAnchor.center.position = new Vector3((mainScreen.x + 0.5f * mainScreen.width) / GameSettings.UI_SIZE, (mainScreen.y + 0.5f * mainScreen.height) / GameSettings.UI_SIZE, 0);
            if (UI.leftAnchor.center != null)
                UI.leftAnchor.center.position = new Vector3(mainScreen.x / GameSettings.UI_SIZE, (mainScreen.y + 0.5f * mainScreen.height) / GameSettings.UI_SIZE, 0);
            if (UI.rightAnchor.top != null)
                UI.rightAnchor.top.position = new Vector3((mainScreen.x + mainScreen.width) / GameSettings.UI_SIZE, (mainScreen.y + mainScreen.height) / GameSettings.UI_SIZE, 0);
            if (UI.centerAnchor.top != null)
                UI.centerAnchor.top.position = new Vector3((mainScreen.x + 0.5f * mainScreen.width) / GameSettings.UI_SIZE, (mainScreen.y + mainScreen.height) / GameSettings.UI_SIZE, 0);
            if (UI.leftAnchor.top != null)
                UI.leftAnchor.top.position = new Vector3(mainScreen.x / GameSettings.UI_SIZE, (mainScreen.y + mainScreen.height) / GameSettings.UI_SIZE, 0);
        }

        public static float TryGetValue(this ConfigNode node, string value, float defaultVal = 0)
        {
            if (node.HasValue(value))
            {
                float x;
                if (float.TryParse(node.GetValue(value), out x))
                    return x;
            }
            return defaultVal;
        }
    }
}