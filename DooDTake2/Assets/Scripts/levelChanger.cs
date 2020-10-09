using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelChanger : MonoBehaviour
{
    //GameMaster gm;
    // Start is called before the first frame update
    void Start()
    {
        //gm = GameObject.Find("GameMaster").GetComponent<GameMaster>();
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("Player")) {
            //gm.lvlIndex++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }
}
