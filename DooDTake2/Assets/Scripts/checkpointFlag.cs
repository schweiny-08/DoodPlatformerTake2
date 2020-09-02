using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointFlag : MonoBehaviour
{
    //private bool isAcativated;
    private Animator anim;
    private Vector2 playerPos, flagPos;
    private GameMaster gm;

    public RuntimeAnimatorController activatedFlag;

    // Start is called before the first frame update
    void Start()
    {
        //isAcativated = false;
        anim = GetComponent<Animator>();
        playerPos = GameObject.Find("Player").transform.position;
        flagPos = GetComponent<Transform>().position;
        gm = GameObject.Find("GameMaster").GetComponent<GameMaster>();
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            anim.runtimeAnimatorController = activatedFlag;
            //isAcativated = true;
            gm.SetSpawnPoint(this.transform.position);
        }
    }
}
