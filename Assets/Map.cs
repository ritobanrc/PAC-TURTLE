using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Map {

    public Vector2Int[] IntersectionPoints { get; protected set; }
    public Tile[,] MapTiles { get; protected set; }
    public int Width {
        get {
            return MapTiles.GetLength(0);
        }
    }
    public int Height {
        get {
            return MapTiles.GetLength(1);
        }
    }

    public Map (Tile[,] mapTiles) {
        MapTiles = mapTiles;
    }


    public void IdentifyIntersectionPoints () {

    }

    public Tile GetTileAt (int x, int y) {
        if (x < 0 || x >= Width || y < 0 || y >= Height) {
            throw new ArgumentOutOfRangeException("x, y", "Map::GetTileAt - (" + x + ", " + y + ") is out of bounds");
        }
        return MapTiles[x, y];
    }
}
