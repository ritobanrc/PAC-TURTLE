using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : MonoBehaviour {

    private const bool IS_AI = false;

    public Player Player;

    private void Awake () {
        if (IS_AI == false) {
            gameObject.AddComponent<PlayerInput>();
        }
    }


    Vector3 currentVelocity;

    private void Update () {
        Vector3 targetPosition = new Vector2(Player.physicalXPos, Player.physicalYPos);
        this.transform.position = 
            Vector3.SmoothDamp(this.transform.position, targetPosition, ref currentVelocity, 0.08f);
        this.transform.GetChild(0).localEulerAngles = new Vector3(0, 0, Mathf.Rad2Deg * Mathf.Atan2(-currentVelocity.x, currentVelocity.y));
    }


}
