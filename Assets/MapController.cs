using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public enum TileType { Empty, Wall, Dot }


public class MapController : Singleton<MapController> {

    [System.Serializable]
    protected class ColorToTileType {
        public Color color;
        public TileType tileType;
    } 

    [SerializeField]
    private Texture2D mapTexture;
    [SerializeField]
    private ColorToTileType[] colorsToTileTypes;

    public Map Map { get; protected set; }
    public int Width {
        get {
            return Map.Width;
        }
    }
    public int Height {
        get {
            return Map.Height;
        }
    }

    private void LoadMap () {
        Tile[,] mapTiles = ProcessMapTexture();
        Map = new Map(mapTiles);
        Map.IdentifyIntersectionPoints();

    }

    private Tile[,] ProcessMapTexture () {
        Tile[,] tiles = new Tile[mapTexture.width, mapTexture.height];
        for (int i = 0; i < mapTexture.width; i++) {
            for (int j = 0; j < mapTexture.height; j++) {
                for (int t = 0; t < colorsToTileTypes.Length; t++) {
                    if (mapTexture.GetPixel(i, j) == colorsToTileTypes[t].color) {
                        tiles[i, j] = new Tile(colorsToTileTypes[t].tileType);
                        break;
                    }
                }
            }
        }
        return tiles;
    }

    public Tile GetTileAt (int x, int y) {
        return Map.GetTileAt(x, y);
    }

    private void Awake () {
        LoadMap();
    }
}
