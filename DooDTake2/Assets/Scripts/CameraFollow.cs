﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        

        if (!player) {
            player = GameObject.FindWithTag("Player").transform;
        }
    }

    public void SetPlayer(GameObject p)
    {
        this.player = p.transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (!player)
        {
            player = GameObject.FindWithTag("Player").transform;
        }
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }

   /* public void SetPlayer(Transform p) {
        player = p;
    }*/
}
