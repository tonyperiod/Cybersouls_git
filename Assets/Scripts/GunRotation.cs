using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : MonoBehaviour
{
    public void SetAimDirection(Vector2 aimAngleVector)
    {
        aimAngleFloat = GetAngleFromVectorFloat(aimAngleVector) + cowardiceAngle;
        // Debug.Log(aimAngleFloat + "aim angle");
    }
}
