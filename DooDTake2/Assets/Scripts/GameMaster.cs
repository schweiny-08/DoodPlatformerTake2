using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {
    public static GameMaster instance;
    public GameObject player;

    public int index;

    private GameObject playerClone;
    private Vector2 spawnPoint;
    private CameraFollow cf;
    private Transform fallPoint;
    private PlayerController playerCont;
    private HealthSystem hs;

    private int maxPlayerHealth, playerHealth;

    public Sprite fullHeart;
    public Sprite heartThreeFour;
    public Sprite heartHalf;
    public Sprite heartQuater;
    public Sprite emptyHeart;

    public Image[] hearts;
    public GameObject[] greenDoods;
    private GameObject[] heartShards;

    private int heartNum, prevHN;

    void Awake() {
        instance = this;
        //DontDestroyOnLoad(gameObject);
    }

    void Start() {
        spawnPoint = GameObject.Find("startPoint").transform.position;
        cf = GameObject.FindWithTag("MainCamera").GetComponent<CameraFollow>();
        maxPlayerHealth = 4;
        playerHealth = maxPlayerHealth;

        greenDoods = GameObject.FindGameObjectsWithTag("GreenDoods");
        heartShards = GameObject.FindGameObjectsWithTag("HeartShard");

        InitialiseHearts();
        //hs = GetComponent<HealthSystem>();
    }

    void Update(){
        StartCoroutine("CheckPlayerHealth");
    }

    public void SetSpawnPoint(Vector2 sp) {
        spawnPoint = sp;
    }

    public void SetPlayerHealth(int h) {
        playerHealth = h;
    }

    public void SetMaxPlayerHealth(int h) {
        
        playerCont = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        maxPlayerHealth += h;
        playerHealth = maxPlayerHealth;
        playerCont.health = playerHealth;
        InitialiseHearts();

        Debug.Log("MAX" + maxPlayerHealth + " PLAYERHEALTH" + playerHealth + " PLAYERCONTHEALTH" + playerCont.health);
    }

    public int GetPlayerHealth() {
        return playerHealth;
    }

    public int GetMaxPlayerHealth() {
        return maxPlayerHealth;
    }

    public void InitialiseHearts() {
        playerHealth = maxPlayerHealth;

        heartNum = maxPlayerHealth / 4;

        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = false;
        }

        for (int i = 0; i < heartNum; i++)
        {
            hearts[i].sprite = fullHeart;
            hearts[i].enabled = true;
        }
    }

    IEnumerator CheckPlayerHealth()
    {
        //health = playerHealth;

        //Debug.Log("HEARTNUM " + heartNum);

        switch (playerHealth % 4)
        {
            case 3:
                hearts[heartNum - 1].sprite = heartThreeFour;
                break;

            case 2:
                hearts[heartNum - 1].sprite = heartHalf;
                break;

            case 1:
                hearts[heartNum - 1].sprite = heartQuater;
                break;

            case 0:

                prevHN = heartNum;
                heartNum = playerHealth / 4;

                // Debug.Log("HEALTH " + playerHealth);

                if (prevHN == heartNum )
                    hearts[heartNum].sprite = emptyHeart;
                else
                    hearts[heartNum].sprite = fullHeart;

               
                //heartNum--;
                break;

            default:
                break;
        }

        yield return new WaitForSeconds(0.1f);
    }

    public void Death(GameObject go) {
        Destroy(go);
    }

    public void Respawn() {

        //if (!GameObject.FindWithTag("Player"))
        //{
            Debug.Log("RESPAWN");
            Instantiate(player, spawnPoint, Quaternion.identity);
            playerCont = player.GetComponent<PlayerController>();
            InitialiseHearts();

            for (int i = 0; i < greenDoods.Length; i++)
            {
                greenDoods[1].GetComponent<PlayerDamageFromEnemy>().damagePoints = 2;
                greenDoods[i].GetComponent<PlayerDamageFromEnemy>().enabled = true;
                greenDoods[i].GetComponent<PolygonCollider2D>().enabled = true;
                greenDoods[i].GetComponent<SpriteRenderer>().enabled = true;
                greenDoods[i].GetComponent<Animator>().enabled = true;
            }

            for (int i = 0; i < heartShards.Length; i++)
            {
                heartShards[i].GetComponent<BoxCollider2D>().enabled = true;
                heartShards[i].GetComponent<SpriteRenderer>().enabled = true;
                heartShards[i].GetComponent<Animation>().enabled = true;
            }
        //}
    }   
}
