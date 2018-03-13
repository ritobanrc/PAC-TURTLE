using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Tile {
    public TileType TileType { get; protected set; }

    public bool IsPassable {
        get {
            return TileType == TileType.Empty || TileType == TileType.Dot;
        }
    }

    public Tile (TileType tileType) {
        TileType = tileType;
    }
}

