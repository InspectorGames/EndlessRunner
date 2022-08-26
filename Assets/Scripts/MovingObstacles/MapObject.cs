using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class MapObject : MonoBehaviour
{
    public MapObjectSO obstacle;
    private ObjectPool<MapObject> pool;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = obstacle.mapObjectSprite;
    }

    private void OnEnable()
    {
        GetComponent<SpriteRenderer>().sprite = obstacle.mapObjectSprite;
    }

    public void Init(MapObjectSO obstacle)
    {
        this.obstacle = obstacle;
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

    public void SetObjectPool(ObjectPool<MapObject> pool)
    {
        this.pool = pool;
    }
}
