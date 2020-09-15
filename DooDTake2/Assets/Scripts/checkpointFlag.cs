using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointFlag : MonoBehaviour
{
    public bool isActivated;
    
    public Animator anim;
    private Vector2 playerPos, flagPos;
    private GameMaster gm;
    private GameObject[] allCheckPoints;
    public RuntimeAnimatorController activatedFlag, deActiveFlag;

    // Start is called before the first frame update
    void Start()
    {
        isActivated = false;
        anim = GetComponent<Animator>();
        playerPos = GameObject.Find("Player").transform.position;
        flagPos = GetComponent<Transform>().position;
        gm = GameObject.Find("GameMaster").GetComponent<GameMaster>();

        allCheckPoints = GameObject.FindGameObjectsWithTag("CheckPoint");
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            anim.runtimeAnimatorController = activatedFlag;
            for (int i = 0; i < allCheckPoints.Length; i++)
            {
                if (allCheckPoints[i]!=gameObject)
                {
                    allCheckPoints[i].GetComponent<checkpointFlag>().isActivated = false;
                    allCheckPoints[i].GetComponent<checkpointFlag>().anim.runtimeAnimatorController = deActiveFlag;
                }

            }
            isActivated = true;
            gm.SetSpawnPoint(this.transform.position);
        }
    }
}
