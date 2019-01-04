using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    public float maxDist;
    public float cameraLerp;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 newPosition = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        float distance = Vector3.Distance(newPosition, transform.position);


        if (distance > maxDist)
        {
            float absX, absY;
            float currentX, currentY;
            float delta = distance - maxDist;
            float newX, newY;

            currentX = transform.position.x;
            currentY = transform.position.y;

            absX = player.transform.position.x - currentX;
            absY = player.transform.position.y - currentY;

            newX = delta * absX / distance;
            newY = delta * absY / distance;

            transform.position = new Vector3(transform.position.x + newX, transform.position.y + newY, transform.position.z);
        }

        if (distance <= maxDist + 1)
        {
            transform.position = Vector3.Lerp(transform.position, newPosition, cameraLerp);
        }

    }
}
