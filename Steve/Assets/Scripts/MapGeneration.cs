using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    public GameObject enemyObject;
    public GameObject resourcePink;
    public GameObject resourceGreen;
    public GameObject resourceBlue;
    public int pinkRarity = 50;
    public int greenRarity = 30;
    public int blueRarity = 20;

    public float mapBound = 300f;
    public int maxResources = 50;
    public int maxEnemies = 10;
    public int seed = 42;

    private Generator resourcePinkGenerator;
    private Generator resourceGreenGenerator;
    private Generator resourceBlueGenerator;
    private Generator enemyGenerator;
    // Start is called before the first frame update
    void Start()
    {
        resourceBlueGenerator = new Generator(seed, mapBound, maxResources - (maxResources * blueRarity) / 100, resourceBlue);
        resourceBlueGenerator.Generate(); //generating blue first

        resourceGreenGenerator = new Generator(seed * 2, mapBound, maxResources - (maxResources * greenRarity) / 100, resourceGreen);
        resourceGreenGenerator.Generate();

        resourcePinkGenerator = new Generator(seed * 3, mapBound, maxResources - (maxResources * pinkRarity) / 100, resourcePink);
        resourcePinkGenerator.Generate(); 

        enemyGenerator = new Generator(seed * maxEnemies, mapBound, maxEnemies, enemyObject);
        enemyGenerator.Generate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
