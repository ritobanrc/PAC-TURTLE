using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility{
    public enum Direction { None, Up, Right, Down, Left }

    public class Util {
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

        /// <summary>
        /// Returns an angle for a direction. 2D, assumes +Y axis is forward
        /// </summary>
        /// <param name="dir">The Direction</param>
        /// <returns>The Angle</returns>
        public static float GetAngleForDirection (Direction dir) {
            switch (dir) {
                case Direction.Down:
                    return 180f;
                case Direction.Left:
                    return 90f;
                case Direction.Right:
                    return -90f;
                case Direction.Up:
                    return 0;
                default:
                    return 0;
            }
        }
    }

}