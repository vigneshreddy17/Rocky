﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    public string LevelToLoad;
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
            //SceneManager.LoadScene(LevelToLoad);
            StartCoroutine(LevelManager.instance.LevelEnd());
        }
    }
}
