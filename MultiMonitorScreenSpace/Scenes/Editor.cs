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
        public void Awake()
        {
            StartCoroutine(camSlow());
        }

        IEnumerator camSlow()
        {
            foreach (Camera c in Camera.allCameras)
            {
                //CameraDebug(c);
                c.renderingPath = RenderingPath.UsePlayerSettings;
                if (c.name.Contains("UI"))
                {
                    continue;
                }
                else
                {
                    Utils.resizeViewPort(c);
                }
            }
            yield return new WaitForSeconds(5);
        }

        public void CameraDebug(Camera c)
        {
            Debug.Log(c.name);
            Debug.Log(c.actualRenderingPath);
            Debug.Log(c.aspect);
            Debug.Log(c.backgroundColor);
            Debug.Log(c.camera);
            Debug.Log(c.cameraToWorldMatrix);
            Debug.Log(c.clearFlags);
            Debug.Log(c.clearStencilAfterLightingPass);
            Debug.Log(c.cullingMask);
            Debug.Log(c.depth);
            Debug.Log(c.depthTextureMode);
            Debug.Log(c.eventMask);
            Debug.Log(c.farClipPlane);
            Debug.Log(c.fieldOfView);
            Debug.Log(c.hdr);
            Debug.Log(c.hideFlags);
            Debug.Log(c.isOrthoGraphic);
            Debug.Log(c.layerCullDistances.Length);
            Debug.Log(c.light);
            Debug.Log(c.nearClipPlane);
            Debug.Log(c.orthographic);
            Debug.Log(c.orthographicSize);
            Debug.Log(c.pixelHeight);
            Debug.Log(c.pixelRect);
            Debug.Log(c.pixelWidth);
            Debug.Log(c.projectionMatrix);
            Debug.Log(c.rect);
            Debug.Log(c.renderingPath);
            Debug.Log(c.stereoConvergence);
            Debug.Log(c.stereoEnabled);
            Debug.Log(c.stereoSeparation);
            Debug.Log(c.targetTexture);
            Debug.Log(c.transparencySortMode);
            Debug.Log(c.useOcclusionCulling);
            Debug.Log(c.velocity);
            Debug.Log(c.worldToCameraMatrix);
        }
    }
}
