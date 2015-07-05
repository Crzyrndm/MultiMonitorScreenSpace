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
            ConfigNode renderSettingsNode = GameDatabase.Instance.GetConfigNodes("MultiScreenSettings").FirstOrDefault();
            if (renderSettingsNode != null)
            {
                ConfigNode mainDisplayNode = renderSettingsNode.GetNode("MainDisplay", 0);
                if (mainDisplayNode != null)
                {
                    Rect displayRect = new Rect(Utils.mainScreen);
                    displayRect.x = mainDisplayNode.TryGetValue("XPos", displayRect.x);
                    displayRect.y = mainDisplayNode.TryGetValue("YPos", displayRect.x);
                    displayRect.width = mainDisplayNode.TryGetValue("Width", displayRect.x);
                    displayRect.height = mainDisplayNode.TryGetValue("Height", displayRect.x);
                    Utils.mainScreen = displayRect;
                }
            }
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
