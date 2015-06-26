using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MultiMonitorScreenSpace.Scenes
{
    using Utility;

    [KSPAddon(KSPAddon.Startup.MainMenu, false)]
    class MainMenu : MonoBehaviour
    {
        public void Awake()
        {
            foreach (Camera c in Camera.allCameras)
            {
                Utils.resizeViewPort(c);
            }
        }
    }
}
