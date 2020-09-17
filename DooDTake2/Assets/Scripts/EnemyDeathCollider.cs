using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathCollider : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player")
        {
            //Debug.Log("AAAH");
            GetComponent<PlayerDamageFromEnemy>().damagePoints = 0;
            GetComponent<PlayerDamageFromEnemy>().enabled = false;
            GetComponent<PolygonCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Animator>().enabled = false;
            //Destroy(gameObject);
        }
        
    }
}
