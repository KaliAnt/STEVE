using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject target;
    public int speed = 5;
    public float rotateSpeed = 5f;
    public float attackRange = 15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = target.transform.position;
        //float angle = Mathf.Atan2(direction.y - transform.position.y, direction.x - transform.position.x) * Mathf.Rad2Deg;
        // Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.back);
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotateSpeed * Time.deltaTime);
        float distanceX = direction.x - transform.position.x;
        float distanceY = direction.y - transform.position.y;
        if ((Mathf.Abs(distanceX) < attackRange) && (Mathf.Abs(distanceY) < attackRange))
        {
            transform.position = Vector2.MoveTowards(transform.position, direction, speed * Time.deltaTime);
        }

        Vector2 dir = new Vector2(
            direction.x - transform.position.x,
            direction.y - transform.position.y
        );

        transform.up = dir;
    }
}
