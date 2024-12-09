using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class TileManager : MonoBehaviour
{
    public static int GridSize = 4;
    private readonly Transform[,] _tilePositions = new Transform[GridSize, GridSize];
    private readonly Tile[,] _tiles = new Tile[GridSize, GridSize];
    [SerializeField] private Tile tilePrefab;

    private void Start()
    {
        GetTilePositions();
        TrySpawnTile();
        TrySpawnTile();
        UpdateTilePositions();
    }

    private void GetTilePositions()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
        int x = 0;
        int y = 0;
        foreach (Transform transform in this.transform)
        {
            _tilePositions[x, y] = transform;
            x++;
            if (x >= GridSize)
            {
                x = 0;
                y++;
            }
        }
    }
    

    private bool TrySpawnTile()
    {
        List<Vector2Int> availableSpots = new List<Vector2Int>();
        
        //add all tiles in the spots list
        for(int x = 0; x< GridSize; x++)
        for (int y = 0; y < GridSize; y++)
        {
            if(_tiles[x,y] == null)
                availableSpots.Add(new Vector2Int(x,y));
            
        }

        if (!availableSpots.Any())
            return false;

        int randomIndex = UnityEngine.Random.Range(0, availableSpots.Count);
        Vector2Int spot = availableSpots[randomIndex];

        var tile = Instantiate(tilePrefab, transform.parent);
        tile.SetValue(GetRandomValue());
        _tiles[spot.x, spot.y] = tile;

        return true;
    }

    private int GetRandomValue()
    {
        var rand = UnityEngine.Random.Range(0f, 1f);
        if (rand <= .8f)
            return 2;
        else
            return 4;
    }
    
    private void UpdateTilePositions()
    {
        for(int x =0; x< GridSize; x++)
        for(int y =0; y< GridSize; y++)
            if (_tiles[x, y] != null)
                _tiles[x, y].transform.position = _tilePositions[x, y].position; 
    }
}
