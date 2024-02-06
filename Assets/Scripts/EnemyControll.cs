using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControll : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rigidbody2d;
    private Vector3 direction;
    public float range;
    public SpriteRenderer enemyBody;
    public Animator animator;

    public int health = 120;

    public GameObject[] bloodSplatters;
    public GameObject enemyHitEffect;
    public float shootRange;
    public bool shoot;
    public GameObject bullet;
    public Transform firePoint;
    public float fireRate;
    public float counter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyBody.isVisible && PlayerControl.instance.gameObject.activeInHierarchy)
        {
            if (Vector3.Distance(transform.position, PlayerControl.instance.transform.position) < range)
            {
                direction = PlayerControl.instance.transform.position - transform.position;
            }
            else
            {
                direction = Vector3.zero;
            }

            direction.Normalize();

            rigidbody2d.velocity = direction * speed;

            if (shoot && Vector3.Distance(transform.position, PlayerControl.instance.transform.position) < shootRange)
            {
                counter = counter - Time.deltaTime;

                if (counter <= 0)
                {
                    counter = fireRate;
                    Instantiate(bullet, firePoint.position, firePoint.rotation);
                }
            }
        }
        else
        {
            rigidbody2d.velocity = Vector2.zero; 
        }

        if (direction != Vector3.zero)
        {
            animator.SetBool("isMoving", true);
        }
        else
            animator.SetBool("isMoving", false);
    }
    

    public void Damage(int enemyDamage)
    {
        health = health - enemyDamage;

        Instantiate(enemyHitEffect, transform.position, transform.rotation);

        if (health <= 0)
        {
            Destroy(gameObject); //destroys enemy when the health is 0

             int currentSplatter = Random.Range(0, bloodSplatters.Length);

            Instantiate(bloodSplatters[currentSplatter], transform.position, transform.rotation);
            //Instantiate(splatter, transform.position, transform.rotation);
        }
    }
}
