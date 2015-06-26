using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace MultiMonitorScreenSpace.Scenes
{
    using Utility;
    [KSPAddon(KSPAddon.Startup.Flight, false)]
    class Flight : MonoBehaviour
    {
        static Callback mapViewEntered, mapViewExited;
        //const string lockstring = "OutOfScreenCameraLock";
        //bool locked = false;

        public void Start()
        {
            foreach (Camera c in Camera.allCameras)
            {
                if (c.name.Contains("UI"))
                    continue;
                Utils.resizeViewPort(c);
            }
            Utils.setUIAnchors();
            // need to resize the cameras for the mapview when they become active
            if (mapViewEntered == null)
            {
                mapViewEntered = MapView.OnEnterMapView;
                MapView.OnEnterMapView = EnteringMapView;
            }
            if (mapViewExited == null)
            {
                mapViewExited = MapView.OnExitMapView;
                MapView.OnExitMapView = LeavingMapView;
            }

            ApplicationLauncher.Instance.anchor.transform.position = new Vector3(ApplicationLauncher.Instance.anchor.transform.position.x * 0.5f, ApplicationLauncher.Instance.anchor.transform.position.y, ApplicationLauncher.Instance.anchor.transform.position.z);
        }

        public void EnteringMapView()
        {
            mapViewEntered.Invoke();
            foreach (Camera c in Camera.allCameras)
            {
                Utils.resizeViewPort(c);
            }
            Utils.resizeViewPort(PlanetariumCamera.fetch.camera);
        }

        public void LeavingMapView()
        {
            mapViewExited.Invoke();
        }
    }
}
