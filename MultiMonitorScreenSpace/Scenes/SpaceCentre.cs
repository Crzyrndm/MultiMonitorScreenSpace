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
                Utils.resizeViewPort(c);
            }
        }
    }
}
