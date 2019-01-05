using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float viewAngle;
    public float viewRadius;
    public GameObject parentPlayer;

    public Vector2 GetDirectionFromAngle(float angleInDegrees)
    {

        float offset = Mathf.Rad2Deg * Mathf.Atan(transform.position.x / transform.position.y);
        angleInDegrees -= parentPlayer.transform.eulerAngles.z - offset;
        if(transform.position.y < 0)
        {
            angleInDegrees -= 180;
        }
        return new Vector2(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
