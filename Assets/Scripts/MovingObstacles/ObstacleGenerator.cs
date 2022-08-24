using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObstacleGenerator : MonoBehaviour
{
    private ObjectPool<ObstacleMover> pool;

    public Obstacle[] obstacles;
    public GameObject obstacleMoverPf;
    public float cooldownToSpawnObstacle;
    public float minCooldownToSpawnObstacle;
    public float cooldownReductionPerSecond;
    private float timer;

    public int xPositionToSpawn;

    public float maxSpeedAdded;
    public float speedIncrementPerSecond;
    private float currentSpeedAdded = 0;

    private void Awake()
    {
        pool = new ObjectPool<ObstacleMover>(CreateObstacleMover, OnTakeObstacleMoverFromPool, OnReturnObstacleMoverToPool, defaultCapacity: 20);
    }

    private void Update()
    {
        if(!Player.GameOver)
        {
            if(minCooldownToSpawnObstacle < cooldownToSpawnObstacle)
            {
                cooldownToSpawnObstacle -= Time.deltaTime * cooldownReductionPerSecond;
            }

            if(currentSpeedAdded < maxSpeedAdded)
            {
                currentSpeedAdded += Time.deltaTime * speedIncrementPerSecond;
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
        foreach (var obstacle in obstacles)
        {
            if(obstacle.probability > Random.Range(0, 100))
            {
                SpawnObstacle(obstacle);
                return;
            }
        }
    }
    private void SpawnObstacle(Obstacle obstacle)
    {
        ObstacleMover obstacleMover = pool.Get();
        obstacleMover.transform.position = new Vector3(xPositionToSpawn, obstacle.yPosition, 0);
        obstacleMover.Init(obstacle, currentSpeedAdded);
    }

    #region Object Pool
    private ObstacleMover CreateObstacleMover()
    {
        ObstacleMover obstacleMover = Instantiate(obstacleMoverPf).GetComponent<ObstacleMover>();
        obstacleMover.SetObjectPool(pool);
        return obstacleMover;
    }

    private void OnTakeObstacleMoverFromPool(ObstacleMover obstacleMover)
    {
        obstacleMover.gameObject.SetActive(true);
    }

    private void OnReturnObstacleMoverToPool(ObstacleMover obstacleMover)
    {
        obstacleMover.gameObject.SetActive(false);
    }
    #endregion
}
