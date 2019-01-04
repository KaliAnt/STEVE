using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceController : MonoBehaviour
{

    public float maxCapacity;
    public float currentCapacity;
    public Image capacityBar;
    public Image bar;

    // Use this for initialization
    void Start()
    {

        maxCapacity = 200;
        bar.enabled = false;
        currentCapacity = maxCapacity;
        capacityBar.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            mineResource(20.0f);
        }
    }

    public float mineResource(float minePower)
    {
        float minedQuantity = 0;


        if (currentCapacity <= minePower)
        {
            minedQuantity = currentCapacity;
            Destroy(gameObject);
        }
        else
        {
            currentCapacity -= minePower;
        }

        bar.enabled = true;
        capacityBar.fillAmount = (maxCapacity - currentCapacity) / maxCapacity;
        return minedQuantity;
    }


}
