using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour{
    public Sprite fullHeart;
    public Sprite heartThreeFour;
    public Sprite heartHalf;
    public Sprite heartQuater;

    public Image[] hearts;

    private int maxHealth, maxHealthTemp;
    private int health, maxHealthHearts;

    private PlayerController pc;
    private GameMaster gm;

    void Start() {
        pc = GetComponent<PlayerController>();
        gm = GameObject.Find("GameMaster").GetComponent<GameMaster>();

        maxHealth = gm.GetMaxHealth();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateMaxHealth() {
        maxHealth += 4;
    }
}
