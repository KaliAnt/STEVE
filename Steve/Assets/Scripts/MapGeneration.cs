using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    public GameObject enemyObject;
    public GameObject resourceObject;
    public float mapBound = 300f;
    public int maxResources = 50;
    public int maxEnemies = 10;
    public int seed = 42;

    private Generator resourceGenerator;
    private Generator enemyGenerator;
    // Start is called before the first frame update
    void Start()
    {
        resourceGenerator = new Generator(seed * maxResources, mapBound, maxResources, resourceObject);
        resourceGenerator.Generate();

        enemyGenerator = new Generator(seed * maxEnemies, mapBound, maxEnemies, enemyObject);
        enemyGenerator.Generate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
