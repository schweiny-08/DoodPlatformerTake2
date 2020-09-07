using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour{

    public int damagePoints;
    
    /*private float knockback;
    private float knockbackLength;
    private float knockbackCount;
    private bool knockFromRight;*/

    private GameObject player;
    private PlayerController pc;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        pc = player.GetComponent<PlayerController>();

        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!player)
        {
            player = GameObject.FindWithTag("Player");
            pc = player.GetComponent<PlayerController>();
        }
        if (col.gameObject.tag == "Player")
        {
            //pc.knockback = damagePoints;
            //pc.knockbackLength = damagePoints / 10;

            pc.UpdateHealth(-damagePoints);

            //Setting knockback
            pc.knockbackCount = pc.knockbackLength;

            if (player.transform.position.x > gameObject.transform.position.x)
                //enemy is on left of player (since player x pos is bigger)
                pc.knockFromRight = false;
            else
                //enemy is on right of player
                pc.knockFromRight = true;
        }
    }

   /* public bool GetFromRight() {
        return knockFromRight;
    }
    public float GetKnockback() {
        return knockback;
    }
    public float GetKnockCount()
    {
        return knockbackCount;
    }
    public float GetKnockLength()
    {
        return knockbackLength;
    }*/
}
