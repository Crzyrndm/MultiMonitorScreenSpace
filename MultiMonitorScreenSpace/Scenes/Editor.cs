using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace MultiMonitorScreenSpace.Scenes
{
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
            { // now only the fov is FUBAR'd
                if (!Utils.CamsResized.Contains(c.name) || c.pixelRect.width == Screen.width)
                    Utils.resizeViewPort(c);
            }
            if (!Utils.CamsResized.Contains(EditorCamera.Instance.camera.name) || EditorCamera.Instance.camera.pixelRect.width == Screen.width)
            {
                Utils.resizeViewPort(EditorCamera.Instance.camera);
            }
        }
    }
}
