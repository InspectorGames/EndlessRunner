using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObstacleMover : MonoBehaviour
{
    public Obstacle obstacle;
    private float leftSpeed;
    private float speedAdded;
    private Rigidbody2D rb;
    private ObjectPool<ObstacleMover> pool;

    private void Start()
    {
        leftSpeed = obstacle.leftSpeed + speedAdded;
        GetComponent<SpriteRenderer>().sprite = obstacle.obstacleSprite;
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        leftSpeed = obstacle.leftSpeed + speedAdded;
        GetComponent<SpriteRenderer>().sprite = obstacle.obstacleSprite;
    }

    private void Update()
    {
        rb.velocity = -transform.right * Time.deltaTime * leftSpeed;
    }

    public void Init(Obstacle obstacle, float speedAdded)
    {
        this.obstacle = obstacle;
        this.speedAdded = speedAdded;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ObstacleRemover"))
        {
            if(pool == null)
            {
                Destroy(this.gameObject);
            }
            else
            {
                pool.Release(this);
            }
        }
    }

    public void SetObjectPool(ObjectPool<ObstacleMover> pool)
    {
        this.pool = pool;
    }
}
