using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBreakable : MonoBehaviour
{

    public bool shouldDrop;
    public GameObject[] items;
    public float itemDropChance;

 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Bullet" || collision.tag == "Player")
        {
            Destroy(gameObject);
            AudioManager.audioManager.PlaySFX(0);

            if (shouldDrop)
            {
                float dropChance = Random.Range(0f, 100f);

                if (dropChance < itemDropChance)
                {
                    int randomItem = Random.Range(0, items.Length);

                    Instantiate(items[randomItem], transform.position, transform.rotation);
                }
            }
        }
    }
}
