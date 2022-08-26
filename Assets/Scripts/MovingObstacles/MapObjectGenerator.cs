using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class MapObjectGenerator : MonoBehaviour
{
    private ObjectPool<MapObject> pool;

    public Transform target;

    public MapObjectSO[] obstacles;
    public MapObjectSO coin;
    public GameObject obstacleMoverPf;
    public float cooldownToSpawnObstacle;
    public float minCooldownToSpawnObstacle;
    public float cooldownReductionPerSecond;
    private float timer;

    private MapObjectProbHandler[] obstacleProbabilities;

    public int xPositionToSpawn;

    private void Awake()
    {
        pool = new ObjectPool<MapObject>(CreateObstacleMover, OnTakeObstacleMoverFromPool, OnReturnObstacleMoverToPool, defaultCapacity: 20);
    }

    private void Start()
    {
        obstacleProbabilities = new MapObjectProbHandler[obstacles.Length];
        for(int i = 0; i < obstacleProbabilities.Length; i++)
        {
            MapObjectSO indexObstacle = obstacles[i];
            obstacleProbabilities[i] = new MapObjectProbHandler(indexObstacle);
        }
    }

    private void Update()
    {
        if(!Player.GameOver)
        {
            if(minCooldownToSpawnObstacle < cooldownToSpawnObstacle)
            {
                cooldownToSpawnObstacle -= Time.deltaTime * cooldownReductionPerSecond;
            }
        }

        timer += Time.deltaTime;
        if(timer > cooldownToSpawnObstacle)
        {
            SelectObstacleToSpawn();
            timer = 0;
        }
    }

    private void SelectObstacleToSpawn()
    {
        bool obstacleSelected = false;
        while(!obstacleSelected)
        {
            foreach (MapObjectProbHandler obstacle in obstacleProbabilities)
            {
                if(obstacle.actualProbability > Random.Range(0, 100))
                {
                    SpawnObstacle(obstacle.mapObjectData);
                    obstacle.RemoveProbability();
                    foreach(MapObjectProbHandler ob in obstacleProbabilities)
                    {
                        if (!ob.Equals(obstacle))
                        {
                            ob.AddProbability();
                        }
                    }
                    obstacleSelected = true;

                    //Spawn Coin
                    break;
                }
            }
        }
    }
    private void SpawnObstacle(MapObjectSO obstacle)
    {
        MapObject obstacleMover = pool.Get();
        obstacleMover.transform.position = new Vector3(target.position.x + xPositionToSpawn + 0.5f, (int) obstacle.yPosition + 0.5f, 0);
        obstacleMover.Init(obstacle);
    }

    #region Object Pool
    private MapObject CreateObstacleMover()
    {
        MapObject obstacleMover = Instantiate(obstacleMoverPf).GetComponent<MapObject>();
        obstacleMover.SetObjectPool(pool);
        return obstacleMover;
    }

    private void OnTakeObstacleMoverFromPool(MapObject obstacleMover)
    {
        obstacleMover.gameObject.SetActive(true);
    }

    private void OnReturnObstacleMoverToPool(MapObject obstacleMover)
    {
        obstacleMover.gameObject.SetActive(false);
    }
    #endregion
}
