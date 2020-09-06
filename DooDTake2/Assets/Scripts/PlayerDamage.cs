using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour{

    public int damagePoints;

    private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!player)
            player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        if(col.gameObject.tag == "Player")
            player.UpdateHealth(-damagePoints);
    }
}
