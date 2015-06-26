using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MultiMonitorScreenSpace.Scenes
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class Loading : MonoBehaviour
    {
        public void Awake()
        {
            //if (Utils.mainScreen == null)
            Utils.mainScreen = new Rect(0, 0, 1920, Screen.height);

            foreach (Camera c in Camera.allCameras)
            {
                Utils.resizeViewPort(c);
            }

            Utils.createBlackoutCameras();
        }
    }
}
