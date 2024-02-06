using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    public float waitForKey = 2f;
    public string mainMenu;
    public GameObject anyKey;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (waitForKey > 0)
        {
            waitForKey -= Time.deltaTime;
            if (waitForKey <= 0)
            {
                anyKey.SetActive(true);
            }
        }
        else
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene(mainMenu);
            }
        }
        
    }
}
