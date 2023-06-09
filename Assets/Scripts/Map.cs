using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour
{
    public Vector2Int Size => _size;

    [SerializeField]
    private Vector2Int _size;
   
    private Tile[,] _tiles;
    void Awake()
    {
        _tiles = new Tile[_size.x, _size.y];
    }

    public Vector2Int GetIndex(Vector3 worldPosition)
    {
        var tilePositionInMap = transform.InverseTransformPoint(worldPosition);
        
        var x = Mathf.FloorToInt(tilePositionInMap.x);
        var y = Mathf.FloorToInt(tilePositionInMap.z);
        
        var halfMapSize = _size / 2;
        var mapIndex = new Vector2Int(x, y)  + halfMapSize;

        return mapIndex;
    }
    public Vector3 GetTilePosition(Vector2Int index)
    {        
        var halfMapSize = _size / 2;
        var halfTileSize = Vector2.one / 2;

        var tilePositionXY = index - halfMapSize + halfTileSize;
        return new Vector3(tilePositionXY.x, 0, tilePositionXY.y);
    }

    public bool IsSellIsAvalible(Vector2Int index)
    {
        var isOutOfGrid = index.x < 0 || index.y < 0 ||
                          index.x >= _tiles.GetLength(0) || index.y >= _tiles.GetLength(1);
        if (isOutOfGrid)
        {
            return false;
        } 
        return (_tiles[index.x, index.y] == null);
    }

    public void SetTile(Vector2Int index, Tile tile)
    {
        _tiles[index.x, index.y] = tile;
    }
    
}
