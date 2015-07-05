using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace MultiMonitorScreenSpace.Scenes
{
    using Utility;
    
    [KSPAddon(KSPAddon.Startup.SpaceCentre, false)]
    class SpaceCentre : MonoBehaviour
    {
        bool ACOpen = false;
        public void Start()
        {
            foreach (Camera c in Camera.allCameras)
            {
                // don't block the UI cameras in this scene
                Utils.resizeViewPort(c);
            }
            Utils.setUIAnchors();

            GameEvents.onGUIAstronautComplexSpawn.Add(AstronautComplexSpawn);
            GameEvents.onGUIAstronautComplexDespawn.Add(AstronautComplexDespawn);
        }

        public void AstronautComplexSpawn()
        {
            ACOpen = true;
        }

        public void AstronautComplexDespawn()
        {
            ACOpen = false;
        }

        public void Update()
        {
            if (ACOpen && Input.GetKeyDown(KeyCode.Escape))
            {

            }
        }

        public void OnDestroy()
        {
            GameEvents.onGUIAstronautComplexSpawn.Remove(AstronautComplexSpawn);
            GameEvents.onGUIAstronautComplexDespawn.Remove(AstronautComplexDespawn);
        }
    }
}
