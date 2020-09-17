using System.Collections;
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
        if(pc == null)
            pc = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        if (col.gameObject.tag == "Player" && gm.GetMaxPlayerHealth() > gm.GetPlayerHealth()) {
            pc.UpdateHealth(health);

            //GetComponent<PlayerDamageFromEnemy>().damagePoints = 0;
            //GetComponent<PlayerDamageFromEnemy>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Animation>().enabled = false;
            //gm.SetPlayerHealth(health);
            //Destroy(gameObject);
        }
    }
}
