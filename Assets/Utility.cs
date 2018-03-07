using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public enum Direction { None, Up, Right, Down, Left }

public class Utility {
    public static Direction GetDirectionFromDeltas (int dx, int dy) {
        if (dx == 0 && dy == 1)
            return Direction.Up;
        else if (dx == 1 && dy == 0)
            return Direction.Right;
        else if (dx == 0 && dy == -1)
            return Direction.Down;
        else if (dx == -1 && dy == 0)
            return Direction.Left;
        else
            return Direction.None;
    }

    public static int GetXForDirection (Direction dir) {
        if (dir == Direction.Right)
            return 1;
        if (dir == Direction.Left)
            return -1;
        else
            return 0;
    }

    public static int GetYForDirection (Direction dir) {
        if (dir == Direction.Up)
            return 1;
        if (dir == Direction.Down)
            return -1;
        else
            return 0;
    }
}

