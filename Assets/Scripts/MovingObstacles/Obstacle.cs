using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Endless Runner/Obstacle", fileName = "New Obstacle")]
public class Obstacle : ScriptableObject
{
    public string obstacleName;
    public Sprite obstacleSprite;
    
    [Range(-2f, 10f)]
    public float yPosition;
    [Range(0f, 1000f)]
    public float leftSpeed;
    [Range(0, 100)]
    public float probability;
}
