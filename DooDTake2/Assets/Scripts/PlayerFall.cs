using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFall : MonoBehaviour{
    private GameMaster gm;

    void Start() {
        if (gm == null)
            gm = GameObject.Find("GameMaster").GetComponent<GameMaster>();
    }

    private void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.name.Equals("fallPoint")){
            gm.Death(gameObject);
            gm.Respawn();            
        }
    }
}
