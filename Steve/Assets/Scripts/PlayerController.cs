using System.Collections;
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
    public int maxNrOfMinions;
    public int currentNrOfMinions;
    public int minionSpawnForce;
    public float speed;

    public float resources;
    public Text text;


    // Use this for initialization
    void Start()
    {
        transform = GetComponent<Transform>();
        rigidBody = GetComponent<Rigidbody2D>();
        currentNrOfMinions = 0;
        resources = 0;
    }

    // Update is called once per frame
    void Update()
    {

        float movementX = joyStick.Horizontal;
        float movementY = joyStick.Vertical;

        if (movementY != 0 || movementX != 0)
        {
            rigidBody.velocity = new Vector2(movementX * speed, movementY * speed);
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
        resources += minedResource * 100;
        text.text = (int)resources + "#";
        currentNrOfMinions--;
    }

    private void RotatePlayer()
    {
        float movementX = rotateStick.Horizontal;
        float movementY = rotateStick.Vertical;
        double angle;


        if (movementY != 0 || movementX != 0)
        {
            angle = Mathf.Atan2(movementX, movementY) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, (float)angle);
        }

    }

    public void spawnMinion(GameObject target)
    {
        if (currentNrOfMinions < maxNrOfMinions)
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