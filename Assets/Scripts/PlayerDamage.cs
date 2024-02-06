using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            AudioManager.audioManager.PlaySFX(11);
            PlayerHealthControll.playerHealthControll.playerDamage();
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            AudioManager.audioManager.PlaySFX(11);
            PlayerHealthControll.playerHealthControll.playerDamage();
        }
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            AudioManager.audioManager.PlaySFX(11);
            PlayerHealthControll.playerHealthControll.playerDamage();
        }
    }

    private void OnCollisionStay2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            AudioManager.audioManager.PlaySFX(11);
            PlayerHealthControll.playerHealthControll.playerDamage();
        }
    }
}
