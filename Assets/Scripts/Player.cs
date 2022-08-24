using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Action OnPlayerTouchedObstacle;
    public static bool GameOver = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            OnPlayerTouchedObstacle?.Invoke();
            GameOver = true;
            gameObject.SetActive(false);
        }
    }
}
