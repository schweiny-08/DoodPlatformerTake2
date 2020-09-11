using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFall : MonoBehaviour{
    private GameMaster gm;
    private AudioSource audio;
    private Rigidbody2D rb;

    public AudioClip doodDead;

    void Start() {
        if (gm == null)
            gm = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        audio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.name.Equals("fallPoint")){
            
            StartCoroutine(DeathAnim());

            
            gm.Respawn();
        }
    }

    IEnumerator DeathAnim() {
        rb.freezeRotation = false;
        transform.rotation *= Quaternion.Euler(0, 0, 90f);// * 20f * Time.deltaTime);//10f = rotate speed

        gameObject.GetComponent<PolygonCollider2D>().enabled = false;

        audio.PlayOneShot(doodDead, 0.5f);

        yield return new WaitForSeconds(1f);

        gm.Death(gameObject);

    }
}
