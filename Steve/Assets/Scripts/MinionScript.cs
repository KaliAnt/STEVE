using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionScript : MonoBehaviour
{

    public GameObject ownerPlayer;
    public float speed;

    public LayerMask resourceLayer;
    public GameObject target;
    private Rigidbody2D minionBody;
    private bool destinationAquired;
    public float miningPower;


    private float minedQuantity;
    private float radius;
    private float offsetX, offsetY;
    // Use this for initialization
    void Start()
    {
        minionBody = GetComponent<Rigidbody2D>();
        minedQuantity = 0f;
        radius = transform.localScale.x + transform.localScale.y;

        destinationAquired = false;
        offsetX = Random.value * radius * 2 - radius;
        offsetY = Random.value * radius * 2 - radius;
    }


    // Update is called once per frame
    void Update()
    {
        if (ownerPlayer != null)
        {
            if (destinationAquired == false)
            {
                Vector3 destination = new Vector3(target.transform.position.x + offsetX, target.transform.position.y + offsetY);
                if (transform.position != destination)
                {
                    transform.position = Vector3.MoveTowards(transform.position, destination, speed);
                }
                else
                {
                    destinationAquired = true;
                    minionBody.velocity = Vector3.zero;
                }

            }
            else
            {
                if (target == null)
                {
                    Vector3 home = new Vector3(ownerPlayer.transform.position.x, ownerPlayer.transform.position.y);
                    if (transform.position != home)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, home, speed);
                    }
                    else
                    {
                        PlayerController playerController = ownerPlayer.GetComponent<PlayerController>();
                        playerController.minionReturn(minedQuantity);
                        Destroy(gameObject);
                    }
                }
                else
                {
                    ResourceController resourceCtrl = target.GetComponent<ResourceController>();
                    minedQuantity += resourceCtrl.mineResource(miningPower);
                }

            }
        }


    }
}

