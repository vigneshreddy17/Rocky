using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthControll : MonoBehaviour
{

    public static PlayerHealthControll playerHealthControll;

    public int curHealth;
    public int maxHealth;

    public float damageInvicibleLength = 1f;
    private float invCount;

    public void Awake()
    {
        playerHealthControll = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth; //as soon as the game starts currentHealth will be equal to maxHealth

        UIController.uIController.healthSlider.maxValue = maxHealth;
        UIController.uIController.healthSlider.value = curHealth;
        UIController.uIController.healthText.text = curHealth.ToString() + " / " + maxHealth.ToString();
    }
     
    // Update is called once per frame
    void Update()
    {
        if (invCount > 0)
        {
            invCount = invCount - Time.deltaTime;
        }
    }

    public void playerDamage()
    {
        if (invCount <= 0)
        {
            curHealth = curHealth - 1;
            invCount = damageInvicibleLength;
            if (curHealth <= 0)
            {
                PlayerControl.instance.gameObject.SetActive(false);
                UIController.uIController.deathScreen.SetActive(true);
                AudioManager.audioManager.PlayDeathMusic();
            }
        }

        UIController.uIController.healthSlider.value = curHealth;
        UIController.uIController.healthText.text = curHealth.ToString() + " / " + maxHealth.ToString();
    }

    public void PlayerHeal(int amt)
    {
        curHealth = curHealth + amt;

        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }

        UIController.uIController.healthSlider.value = curHealth;
        UIController.uIController.healthText.text = curHealth.ToString() + " / " + maxHealth.ToString();
    }
}
