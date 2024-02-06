using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{

    public int heal = 1;
    public float waitToCollect = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (waitToCollect > 0)
        {
            waitToCollect -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && waitToCollect <= 0)
        {
            PlayerHealthControll.playerHealthControll.PlayerHeal(heal);
            Destroy(gameObject);
        }
    }
}
