using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator
{
    public int itemCount = 20;
    public float mapBound = 300f;

    public List<GameObject> mapObjects;
    private GameObject source;

    public Generator(int seed, float mapBound, int itemCount, GameObject prefab)
    {
        this.mapBound = mapBound;
        this.itemCount = itemCount;
        this.source = prefab;

        UnityEngine.Random.InitState(seed);
        mapObjects = new List<GameObject>();

    }

    public void Generate()
    {
        var type = source.gameObject;
        for (int i = 0; i < itemCount; i++)
        {
            GameObject o = GameObject.Instantiate(source, getObjectPosition(), Quaternion.identity);
            mapObjects.Add(o);
        }
    }

    private Vector3 getObjectPosition()
    {
        
        Vector3 vector = new Vector3(Random.Range(-mapBound, mapBound), Random.Range(-mapBound, mapBound), 0);
        if (validateVector3(vector))
            return vector;
        return getObjectPosition();

    }

    private bool validateVector3(Vector3 proposal)
    {
        foreach(GameObject current in mapObjects) {
            if (Mathf.Abs(current.transform.position.x - proposal.x) < 3 && Mathf.Abs(current.transform.position.y - proposal.y) < 3)
                if(proposal.x < mapBound && proposal.x > -mapBound && proposal.y < mapBound && proposal.y > -mapBound)
                    return false;
        }
        return true;
    }
}
