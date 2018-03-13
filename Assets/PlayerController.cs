using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class PlayerController : MonoBehaviour {

    public Player Player;
    public Tile PlayerTile {
        get {
            return MapController.Instance.GetTileAt(Player.X, Player.Y);
        }
    }
    public Tile NextPlayerTile {
        get {
            Vector2Int nextPlayerLocation = new Vector2Int(Player.X, Player.Y) +
                new Vector2Int(Util.GetXForDirection(Player.Direction), Util.GetYForDirection(Player.Direction));
            try {
                return MapController.Instance.GetTileAt(nextPlayerLocation.x, nextPlayerLocation.y);
            } catch (ArgumentOutOfRangeException) {
                return null;
            }
        }
    }

    private float PlayerSpeed = 5;


    public void ChangePlayerDirection (int h, int v) {
        Direction dir = Util.GetDirectionFromDeltas(h, v);
        if (dir == Player.Direction)
            return;
        Player.Direction = dir;
        Player.physicalXPos = Player.X;
        Player.physicalYPos = Player.Y;
    }

    private PlayerObject playerObject;


    private void CreatePlayer () {
        Player = new Player(16, 13);
        playerObject.Player = Player;
    }

    private void Awake () {
        playerObject = GameObject.FindObjectOfType<PlayerObject>();
        if (playerObject == null)
            Debug.LogError("PlayeController::Start - No PlayerObject found in Scene");
        CreatePlayer();
    }

    private void Update () {
        //Debug.Log(Player.X + " " + Player.Y + " " + PlayerTile.TileType);
        if (NextPlayerTile != null && NextPlayerTile.IsPassable == false) {
            Player.IsMoving = false;
            return;
        }
        Player.IsMoving = true;
        Player.physicalXPos += PlayerSpeed * Time.deltaTime * Util.GetXForDirection(Player.Direction);
        Player.physicalYPos += PlayerSpeed * Time.deltaTime * Util.GetYForDirection(Player.Direction);
        if (Mathf.RoundToInt(Player.physicalXPos) != Player.X) {
            Player.X = Mathf.RoundToInt(Player.physicalXPos);
            if (Player.X % MapController.Instance.Width != Player.X) {
                Player.X = Player.X % MapController.Instance.Width;
                Player.physicalXPos = Player.X;
            } else if (Player.X == 0) {
                Player.X = MapController.Instance.Width - 1;
                Player.physicalXPos = Player.X;

            }
        }
        if (Mathf.RoundToInt(Player.physicalYPos) != Player.Y) {
            Player.Y = Mathf.RoundToInt(Player.physicalYPos);
        }
    }

}
