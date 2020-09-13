﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRegen : MonoBehaviour
{
    public int health;

    private PlayerController pc;
    private GameMaster gm;


    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        pc = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            pc.UpdateHealth(health);
            //gm.SetPlayerHealth(health);
            Destroy(gameObject);
        }
    }
}
