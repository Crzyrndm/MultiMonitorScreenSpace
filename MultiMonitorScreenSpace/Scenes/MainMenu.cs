using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MultiMonitorScreenSpace.Scenes
{
    using Utility;

    [KSPAddon(KSPAddon.Startup.MainMenu, true)]
    class MainMenu : MonoBehaviour
    {
        public void Awake()
        {
            foreach (Camera c in Camera.allCameras)
            {
                if (c.name == "UI camera" || c.name == "UI mask camera")
                    continue;
                Utils.resizeViewPort(c);
            }

            Utils.setUIAnchors();
        }
    }
}
