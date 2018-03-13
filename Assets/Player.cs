using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class Player {
    private Direction direction;

    public int X { get; set; }
    public int Y { get; set; }
    public bool IsMoving { get; set; }
    public Direction Direction {
        get {
            return direction;
        }
        set {
            direction = value;
            if (OnDirectionChanged != null)
                OnDirectionChanged(this, value);
        }
    }

    public float physicalXPos;
    public float physicalYPos;

    private readonly float playerSpeed;

    #region Delegate Hooks
    public event Action<Player, Direction> OnDirectionChanged;
    #endregion

    public Player (int startX, int startY) {
        X = startX;
        Y = startY;
        physicalXPos = startX;
        physicalYPos = startY;
    }
}
