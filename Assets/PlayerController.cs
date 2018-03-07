using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Player Player;

    private float PlayerSpeed = 8;
    

    public void ChangePlayerDirection (int h, int v) {
        Direction dir = Utility.GetDirectionFromDeltas(h, v);
        if (dir == Player.Direction)
            return;
        Player.Direction = dir;
        Player.physicalXPos = Player.X;
        Player.physicalYPos = Player.Y;
    }

    private PlayerObject playerObject;

    private void CreatePlayer () {
        Player = new Player(0, 0);
        playerObject.Player = Player;
    }

    private void Awake () {
        playerObject = GameObject.FindObjectOfType<PlayerObject>();
        if (playerObject == null)
            Debug.LogError("PlayeController::Start - No PlayerObject found in Scene");
        CreatePlayer();
    }

    private void Update () {
        Player.physicalXPos += PlayerSpeed * Time.deltaTime * Utility.GetXForDirection(Player.Direction);
        Player.physicalYPos += PlayerSpeed * Time.deltaTime * Utility.GetYForDirection(Player.Direction);
        if (Mathf.RoundToInt(Player.physicalXPos) != Player.X)
            Player.X = Mathf.RoundToInt(Player.physicalXPos);
        if (Mathf.RoundToInt(Player.physicalYPos) != Player.Y)
            Player.Y = Mathf.RoundToInt(Player.physicalYPos);
    }



}
