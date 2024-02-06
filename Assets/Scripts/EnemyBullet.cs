using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        direction = PlayerControl.instance.transform.position - transform.position;
        direction.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            AudioManager.audioManager.PlaySFX(11);
            PlayerHealthControll.playerHealthControll.playerDamage();
        }

        Destroy(gameObject);
        //AudioManager.instance.PlaySFX(4);
    }

    private void OnBecameInvisible()
    {
        AudioManager.audioManager.PlaySFX(9);
        Destroy(gameObject);
    }
}
