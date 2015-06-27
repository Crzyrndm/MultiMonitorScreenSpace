using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MultiMonitorScreenSpace.Scenes
{
    using Utility;

    [KSPAddon(KSPAddon.Startup.TrackingStation, false)]
    class TrackingStation : MonoBehaviour
    {
        public void Awake()
        {
            foreach (Camera c in Camera.allCameras)
            {
                if (c.name.Contains("UI"))
                    continue;
                Utils.resizeViewPort(c);
            }
            Utils.setUIAnchors();
        }

        public void Start()
        {
            Utils.resizeViewPort(PlanetariumCamera.fetch.camera);
        }
    }
}
