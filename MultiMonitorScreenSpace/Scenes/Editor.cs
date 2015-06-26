using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace MultiMonitorScreenSpace.Scenes
{
    using Utility;

    [KSPAddon(KSPAddon.Startup.EditorAny, false)]
    class Editor : MonoBehaviour
    {
        public void Start()
        {
            StartCoroutine(editorInit());
        }

        IEnumerator editorInit()
        {
            while (EditorDriver.editorFacility == EditorFacility.None)
                yield return null;
            foreach (Camera c in Camera.allCameras)
            {
                Debug.Log(c.name);
                if (c.name.Contains("UI"))
                    continue;
                Utils.resizeViewPort(c);
            }
            Utils.resizeViewPort(EditorCamera.Instance.camera);
            Utils.setUIAnchors();
        }
    }
}
