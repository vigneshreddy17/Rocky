using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float bulletSpeed = 10.0f;
    public Rigidbody2D rigidBody;
    public GameObject impact;
    public int damage = 30;
    public int bulletcount = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.velocity = transform.right * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision) //When bullet is fired
    {
        Instantiate(impact, transform.position, transform.rotation);
        Destroy(gameObject);

        if (collision.tag == "Enemy")
        {
            AudioManager.audioManager.PlaySFX(2);
            collision.GetComponent<EnemyControll>().Damage(damage);
        }

        if (collision.tag == "Box")
        {
            AudioManager.audioManager.PlaySFX(0);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
            
        

    }
    

    private void OnBecameInvisible()
    {
        AudioManager.audioManager.PlaySFX(1);
        Destroy(gameObject);
    }
}
