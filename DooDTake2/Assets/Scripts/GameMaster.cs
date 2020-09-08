using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour{
    public static GameMaster instance;
    public GameObject player;
    
    private GameObject playerClone;
    private Vector2 spawnPoint;
    private CameraFollow cf;
    private Transform fallPoint;
    private PlayerController playerCont;

    private int maxPlayerHealth, playerHealth;

    void Awake() {
        instance = this;
    }

    void Start() {
        spawnPoint = GameObject.Find("startPoint").transform.position;
        cf = GameObject.FindWithTag("MainCamera").GetComponent<CameraFollow>();
        maxPlayerHealth = 4;
        playerHealth = maxPlayerHealth;
    }

    public void SetSpawnPoint(Vector2 sp) {
        spawnPoint = sp;
    }

    public void SetPlayerHealth(int h) {
        playerHealth = h;
    }

    public int GetPlayerHealth() {
        return playerHealth;
    }

    public int GetMaxPlayerHealth() {
        return maxPlayerHealth;
    }

    public void Death(GameObject go) {
        Destroy(go);
    }

    public void Respawn() {
        Debug.Log("RESPAWN");
        Instantiate(player, spawnPoint, Quaternion.identity);
        playerCont = GetComponent<PlayerController>();
        playerCont.UpdateHealth(maxPlayerHealth);
    }
}
