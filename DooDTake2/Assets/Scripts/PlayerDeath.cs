using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour{
    private GameMaster gm;

    void Start() {
        if (gm == null)
            gm = GameObject.Find("GameMaster").GetComponent<GameMaster>();
    }

    private void OnCollisionEnter2D(Collision2D col){
        //Debug.Log("COLLISIONS1");
        if (col.gameObject.name.Equals("fallPoint")){
            //Debug.Log("COLLISIONS");
            //Destroy(gameObject);
            gm.Death(gameObject);
            gm.Respawn();
            //GameMaster.instance.Respawn();
            
        }
    }

    void Update() {
        //Debug.Log(gameObject.transform.position);
    }
}
