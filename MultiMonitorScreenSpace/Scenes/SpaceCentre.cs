using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MultiMonitorScreenSpace.Scenes
{
    using Utility;
    
    [KSPAddon(KSPAddon.Startup.SpaceCentre, false)]
    class SpaceCentre : MonoBehaviour
    {
        public void Start()
        {
            foreach (Camera c in Camera.allCameras)
            {
                // don't block the UI cameras in this scene
                Utils.resizeViewPort(c);
            }
        }
    }
}
