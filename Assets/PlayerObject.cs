using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class PlayerObject : MonoBehaviour {

    private const bool IS_AI = false;

    public Player Player;

    private void Awake () {
        if (IS_AI == false) {
            gameObject.AddComponent<PlayerInput>();
        }
    }


    Vector3 currentVelocity;
    float currentAngleVelocity;

    private void Update () {
        Vector3 targetPosition = new Vector2(Player.physicalXPos, Player.physicalYPos);
        if (Vector3.Distance(this.transform.position, targetPosition) > 2)
            this.transform.position = targetPosition;
        this.transform.position =
            Vector3.SmoothDamp(this.transform.position, targetPosition, ref currentVelocity, 0.05f);
        if (currentVelocity != Vector3.zero) {
            float targetAngle = Mathf.Rad2Deg * Mathf.Atan2(-currentVelocity.x, currentVelocity.y);
            this.transform.eulerAngles = new Vector3(0, 0, Mathf.SmoothDampAngle(this.transform.eulerAngles.z, targetAngle, ref currentAngleVelocity, 0.1f));
        }
        if (Player.IsMoving == false)
            this.transform.eulerAngles = new Vector3(0, 0, Util.GetAngleForDirection(Player.Direction));
    }


}
