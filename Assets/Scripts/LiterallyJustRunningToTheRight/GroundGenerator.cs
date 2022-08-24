using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GroundGenerator : MonoBehaviour
{
    public Tilemap groundTilemap;
    public Tile groundTile;

    public int groundPositionY;

    public Transform playerTransform;
    public int distanceToRemoveBackTiles;
    public int distanceToSpawnForwardTiles;

    private int lastTilePlacedX;
    private int nextTileToPlaceX;

    private int lastTileRemovedX = -50;
    private int nextTileToRemoveX;

    private void Start()
    {
        nextTileToPlaceX = distanceToSpawnForwardTiles;
        nextTileToRemoveX = -distanceToRemoveBackTiles;
        GenerateGround();
    }

    private void Update()
    {
        GenerateGround();
        RemoveGround();
    }

    private void GenerateGround()
    {
        List<int> tilesToPlace = new List<int>();
        if(lastTilePlacedX != nextTileToPlaceX)
        {
            for(int i = lastTilePlacedX; i < nextTileToPlaceX; i++)
            {
                tilesToPlace.Add(i);
                lastTilePlacedX++;
            }
        }
        else
        {
            nextTileToPlaceX = (int)(playerTransform.position.x + distanceToSpawnForwardTiles);
        }
        
        foreach(int tileX in tilesToPlace)
        {
            groundTilemap.SetTile(new Vector3Int(tileX, groundPositionY, 0), groundTile);
        }
    }

    private void RemoveGround()
    {
        List<int> tilesToRemove = new List<int>();
        if (lastTileRemovedX != nextTileToRemoveX)
        {
            for (int i = lastTileRemovedX; i < nextTileToRemoveX; i++)
            {
                tilesToRemove.Add(i);
                lastTileRemovedX++;
            }
        }
        else
        {
            nextTileToRemoveX = (int)(playerTransform.position.x - distanceToRemoveBackTiles);
        }

        foreach (int tileX in tilesToRemove)
        {
            groundTilemap.SetTile(new Vector3Int(tileX, groundPositionY, 0), null);
        }
    }

}
