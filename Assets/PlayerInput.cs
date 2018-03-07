using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    private PlayerController playerController;

    private void Awake () {
        playerController = GameObject.FindObjectOfType<PlayerController>();
    }

    private void Update () {
        int h = (int)Input.GetAxisRaw("Horizontal");
        int v = (int)Input.GetAxisRaw("Vertical");
        if (h == 0 && v == 0 || Mathf.Abs(h) + Mathf.Abs(v) > 1)
            return;
        playerController.ChangePlayerDirection(h, v);
    }
}
