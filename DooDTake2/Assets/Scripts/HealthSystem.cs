using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour{
    public Sprite fullHeart;
    public Sprite heartThreeFour;
    public Sprite heartHalf;
    public Sprite heartQuater;
    public Sprite emptyHeart;

    public Image[] hearts;

   /* private int maxHealth, maxHealthTemp;
    private int health, maxHealthHearts;*/

    private PlayerController pc;
    private GameMaster gm;

    private int heartNum, health;


    void Start() {
        //pc = GetComponent<PlayerController>();
        gm = GetComponent<GameMaster>();

        //heartNum = (gm.GetMaxPlayerHealth() / 4);
        Debug.Log("HEALTHSTART");

        //heartNum = (gm.GetMaxPlayerHealth() / 4);

        for (int i = 0; i < hearts.Length; i++)
        {
            //hearts[i].sprite = fullHeart; 
            hearts[i].enabled = false;
        }

        InitialiseHearts();

        /*maxHealth = gm.GetMaxHealth();
        health = maxHealth;*/
    }

    public void InitialiseHearts() {
        heartNum = (gm.GetMaxPlayerHealth() / 4);
        StartCoroutine("CheckMaxHearts");
        Debug.Log("MAXHEALTH" + gm.GetMaxPlayerHealth());
        Debug.Log("HEARTNUM" + heartNum);
    }

    // Update is called once per frame
    void Update()
    {

        

        StartCoroutine("CheckPlayerHealth");
    }

    public void UpdateMaxHealth() {
        //maxHealth += 4;
    }

    IEnumerator CheckMaxHearts() {

        

        for (int i = 0; i < heartNum; i++)
        {
            hearts[i].enabled = true;
        }
        
        yield return new WaitForSeconds(0.2f);
    }

    IEnumerator CheckPlayerHealth() {
        health = gm.GetPlayerHealth();

        switch (health%4)
        {
            case 3:
                hearts[heartNum-1].sprite = heartThreeFour;
                break;

            case 2:
                hearts[heartNum - 1].sprite = heartHalf;
                break;

            case 1:
                hearts[heartNum - 1].sprite = heartQuater;
                break;

            case 0:
                //heartNum = gm.GetPlayerHealth() / 4;
                //Debug.Log("HEARTNUM" + heartNum);
                hearts[heartNum-1].sprite = emptyHeart;
                heartNum--;
                
                break;

            default:
                break;
        }

        yield return new WaitForSeconds(0.1f);
    }
}
