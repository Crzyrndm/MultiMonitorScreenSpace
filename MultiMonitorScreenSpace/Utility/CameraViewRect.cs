using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MultiMonitorScreenSpace.Utils
{
    public class CameraViewRect
    {
        public Camera c { get; set; }
        public Rect rInitial { get; set; }
        public Rect rModified { get; set; }

        public CameraViewRect(Camera cam, Rect initial, Rect modified)
        {
            c = cam;
            rInitial = initial;
            rModified = modified;
        }
    }
}
