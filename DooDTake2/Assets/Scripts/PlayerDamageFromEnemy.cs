using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageFromEnemy : MonoBehaviour
{

    public int damagePoints;
    public AudioClip doodHit;


    private int tempKnock;
    private GameObject player;
    private PlayerController pc;
    private AudioSource audio;
    private GameMaster gm;

    //public AudioClip doodHit;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        pc = player.GetComponent<PlayerController>();
        audio = player.GetComponent<AudioSource>();

        gm = GameObject.Find("GameMaster").GetComponent<GameMaster>();

        //tempKnock = 8;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (!player)
        {
            player = GameObject.FindWithTag("Player");
            pc = player.GetComponent<PlayerController>();
            audio = player.GetComponent<AudioSource>();
        }
        if (col.gameObject.tag == "Player" && !pc.IsDead())
        {
            //pc.knockback = damagePoints;
            //pc.knockbackLength = damagePoints / 10;

            pc.UpdateHealth(-damagePoints);

            if (gm.GetPlayerHealth() > 0)
                audio.PlayOneShot(doodHit, 0.75f);
            //Debug.Log("HIT");
            //Setting knockback
            pc.knockbackCount = pc.knockbackLength;
            //pc.knockback = 8;

            if (player.transform.position.x > gameObject.transform.position.x)
                //enemy is on left of player (since player x pos is bigger)
                pc.knockFromRight = false;
            else
                //enemy is on right of player
                pc.knockFromRight = true;
        }
    }
}
