using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MultiMonitorScreenSpace.Scenes
{
    using Utility;
    [KSPAddon(KSPAddon.Startup.Flight, false)]
    class Flight : MonoBehaviour
    {
        static Callback mapViewEntered;
        //const string lockstring = "OutOfScreenCameraLock";
        //bool locked = false;

        public void Start()
        {
            foreach (Camera c in Camera.allCameras)
            {
                Utils.resizeViewPort(c);
            }
            
            // need to resize the cameras for the mapview when they become active
            if (mapViewEntered == null)
            {
                mapViewEntered = MapView.OnEnterMapView;
                MapView.OnEnterMapView = EnteringMapView;
            }
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
    }
}
