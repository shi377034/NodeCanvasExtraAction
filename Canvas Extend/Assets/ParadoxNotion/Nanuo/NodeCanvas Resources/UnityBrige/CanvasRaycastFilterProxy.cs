using UnityEngine;
using System.Collections;
[AddComponentMenu("UI/CanvasRaycastFilter")]
public class CanvasRaycastFilterProxy : MonoBehaviour, ICanvasRaycastFilter
{

    public bool RayCastingEnabled = true;

    public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
    {
        return RayCastingEnabled;
    }
}
