using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MultiMonitorScreenSpace.Scenes
{
    using Utility;

    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class Loading : MonoBehaviour
    {
        public void Awake()
        {
            Utils.mainScreen = new Rect(0, 0, 1920, 1080);

            foreach (Camera c in Camera.allCameras)
            {
                Utils.resizeViewPort(c);
            }

            Utils.createBlackoutCameras();
        }
    }
}
