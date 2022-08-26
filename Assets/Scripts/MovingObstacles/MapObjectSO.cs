using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Endless Runner/Map Object", fileName = "New Map Object")]
public class MapObjectSO : ScriptableObject
{
    public enum Type
    {
        Obstacle,
        Collectable
    }

    public enum YPosition
    {
        Upper = 5,
        Middle = 3,
        Lower = 1
    }

    public string mapObjectName;
    public Sprite mapObjectSprite;

    public Type mapObjectType;
    public YPosition yPosition;
    [Range(0, 100)]
    public float maxProbability;
    [Range(0, 100)]
    public float startingProbability;
    [Range(0, 100)]
    public float probabilityIncrement;
    [Range(0, 100)]
    public float probabilityDecrement;
}
