using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MapViewTest
{
    [KSPAddon(KSPAddon.Startup.Flight, false)]
    public class CamTest : MonoBehaviour
    {
        Callback OnEnter, OnLeave;
        GameObject CameraObject;
        Camera PCam, SSCam, TestCam;
        //public void Start()
        //{
        //    OnEnter = MapView.OnEnterMapView;
        //    MapView.OnEnterMapView = onMapViewEnter;
        //    OnLeave = MapView.OnExitMapView;
        //    MapView.OnExitMapView = onMapViewLeave;

        //    CameraObject = new GameObject("MiniMapView");
        //    Rect viewRect = new Rect(Screen.width / 2, Screen.height / 2, Screen.width / 2, Screen.height / 2);
        //    TestCam = CameraObject.AddComponent<Camera>();
        //    TestCam.CopyFrom(FlightCamera.fetch.cameras[1]);
        //    TestCam.pixelRect = viewRect;
        //    TestCam.depth = 0;
        //    TestCam.farClipPlane = 100000;

        //    PCam = CameraObject.AddComponent<Camera>();
        //    PCam.CopyFrom(PlanetariumCamera.Camera);
        //    PCam.pixelRect = viewRect;
        //    PCam.depth = 1;

        //    SSCam = CameraObject.AddComponent<Camera>();
        //    SSCam.CopyFrom(ScaledCamera.Instance.camera);
        //    SSCam.pixelRect = viewRect;
        //    SSCam.depth = 2;

        //    SSCam.enabled = PCam.enabled = true;
        //}

        //public void LateUpdate()
        //{
        //    CameraObject.transform.position = FlightGlobals.ActiveVessel.transform.position;
        //    CameraObject.transform.LookAt(FlightGlobals.ActiveVessel.mainBody.transform.position);
        //    CameraObject.transform.Translate(0, 0, -FlightCamera.fetch.Distance * 100);
        //}

        //public void onMapViewEnter()
        //{
        //    OnEnter.Invoke();
        //    Debug.Log("entered map view");
        //}

        //public void onMapViewLeave()
        //{
        //    OnLeave.Invoke();
        //    Debug.Log("left map view");
        //}
    }
}
