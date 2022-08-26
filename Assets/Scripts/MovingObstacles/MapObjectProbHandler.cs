using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObjectProbHandler
{
    public MapObjectSO mapObjectData;
    public float maxProbability;
    public float actualProbability;

    public MapObjectProbHandler(MapObjectSO mapObject)
    {
        this.mapObjectData = mapObject;
        this.maxProbability = mapObject.maxProbability;
        actualProbability = mapObject.startingProbability;
    }

    public void RemoveProbability()
    {
        if(actualProbability - 10 >= 0)
        {
            actualProbability -= 10;
            Debug.Log("(Removed) Actual Probability: " + mapObjectData.probabilityIncrement);
        }
    }

    public void AddProbability()
    {
        if(actualProbability + 10 < maxProbability)
        {
            actualProbability += 10;
            Debug.Log("(Added) Actual Probability: " + mapObjectData.probabilityDecrement);
        }
    }
}
