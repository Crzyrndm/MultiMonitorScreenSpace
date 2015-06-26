using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MultiMonitorScreenSpace.Scenes
{
    [KSPAddon(KSPAddon.Startup.Flight, false)]
    class Flight : MonoBehaviour
    {
        static Callback mapViewEntered;
        const string lockstring = "OutOfScreenCameraLock";
        bool locked = false;

        public void Start()
        {
            foreach (Camera c in Camera.allCameras)
            {
                if (!Utils.CamsResized.Contains(c.name))
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
                if (!Utils.CamsResized.Contains(c.name))
                {
                    Utils.resizeViewPort(c);
                }
            }
            if (PlanetariumCamera.fetch.camera.pixelRect.width == Screen.width)
                Utils.resizeViewPort(PlanetariumCamera.fetch.camera);
        }

        public void Update()
        {
            //if (!Utils.mainScreen.Contains(Input.mousePosition))
            //{
            //    if (!locked)
            //    {
            //        InputLockManager.SetControlLock(ControlTypes.CAMERACONTROLS, lockstring);
            //        locked = true;
            //    }
            //}
            //else
            //{
            //    if (locked)
            //    {
            //        InputLockManager.RemoveControlLock(lockstring);
            //        locked = false;
            //    }
            //}
        }
    }
}
