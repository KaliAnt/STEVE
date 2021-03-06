﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private Transform transform;
    public Joystick joyStick;
    public Joystick rotateStick;
    public GameObject minion;
    public uint maxNrOfMinions;
    public uint currentNrOfMinions;
    public int minionSpawnForce;
    public float speed;
    public float mapBound;

    public uint currency;
    public Text text;

    private List<GameObject> hiddenEyes = new List<GameObject>();
    private List<GameObject> visibleEyes = new List<GameObject>();

    public static Inventory inventory;


    // Use this for initialization
    void Start()
    {
        initializeEyes();
        initializeInventory();
        transform = GetComponent<Transform>();
        rigidBody = GetComponent<Rigidbody2D>();
        currentNrOfMinions = 0;

    }

    void initializeEyes()
    {
        var eyeParent = this.gameObject.transform.GetChild(0);
        int childrenCnt = eyeParent.childCount;

        visibleEyes.Add(eyeParent.GetChild(0).gameObject);

        for (int i = 1; i < childrenCnt; i++)
        {
            var child = eyeParent.GetChild(i).gameObject;
            child.SetActive(false);
            this.hiddenEyes.Add(child);
        }
    }

    void initializeInventory()
    {
        uint[] eyes = { 1, 0, 0, 0, 0 }; //level of eyes, 0 means hidden
        inventory = new Inventory(currency, eyes, speed, maxNrOfMinions);
    }

    public Inventory GetInventory()
    {
        return inventory;
    }

    // Update is called once per frame
    void Update()
    {
        int amount = (int)inventory.GetCurrency();
        text.text = amount.ToString();

        float movementX = joyStick.Horizontal;
        float movementY = joyStick.Vertical;

        if (transform.position.x > mapBound)
            transform.position = new Vector3(mapBound, transform.position.y);
        if (transform.position.x < -mapBound)
            transform.position = new Vector3(-mapBound, transform.position.y);
        if (transform.position.y > mapBound)
            transform.position = new Vector3(transform.position.x, mapBound);
        if (movementY < -mapBound)
            transform.position = new Vector3(transform.position.x, -mapBound);

        if (movementY != 0 || movementX != 0)
        {
            rigidBody.velocity = new Vector2(movementX * inventory.GetSpeed(), movementY * inventory.GetSpeed());
        }
        else
        {
            rigidBody.velocity = Vector2.zero;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "Resource")
                {
                    spawnMinion(hit.collider.gameObject);
                }
            }
        }


        RotatePlayer();

    }

    public void minionReturn(float minedResource)
    {
        inventory.AddCurrencyAmount(minedResource*1000);
        int amount = (int)inventory.GetCurrency();
        text.text = amount.ToString();
        currentNrOfMinions--;
    }

    private void RotatePlayer()
    {
        float movementX = rotateStick.Horizontal;
        float movementY = rotateStick.Vertical;
        double angle;


        if (movementY != 0 || movementX != 0)
        {
            angle = Mathf.Atan2(movementY, movementX) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, (float)angle);
        }

    }

    public void spawnMinion(GameObject target)
    {
        if (currentNrOfMinions < inventory.GetFetchers())
        {
            GameObject instance = (GameObject)Instantiate(minion);
            currentNrOfMinions++;
            SpriteRenderer minionRenderer = instance.GetComponent<SpriteRenderer>();
            SpriteRenderer playerRenderer = GetComponentInChildren<SpriteRenderer>();

            minionRenderer.color = playerRenderer.color;
            instance.transform.position = transform.position;

            Rigidbody2D minionBody = instance.GetComponent<Rigidbody2D>();

            float angle = Random.value * 360 * Mathf.Deg2Rad;
            float forceX, forceY;
            forceX = minionSpawnForce * Mathf.Sin(angle);
            forceY = minionSpawnForce * Mathf.Cos(angle);

            minionBody.velocity = new Vector3(forceX, forceY);
            MinionScript minionScript = instance.GetComponent<MinionScript>();
            minionScript.ownerPlayer = gameObject;
            minionScript.target = target;
        }
    }
}